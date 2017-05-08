#addin nuget:?package=SharpZipLib&version=0.86.0
#addin nuget:?package=Cake.Compression&version=0.1.1
#addin "Cake.Docker"


var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var publishDir = Directory("../tmp/picflow/");
var dockerDir = Directory("./dockerfiles/");

var projects = new Dictionary<string, string>
	{
		{"WebApp","picflow-webapp"},
		{"Uploader","picflow-uploader"},
		{"ExternalApp","picflow-extapp"},
		{"ImageProcessor","picflow-processor"},
		{"ImagePersistor","picflow-persistor"},
		{"Authorization","picflow-authorization"}
	};


Task("Clean")
    .Does(() =>
{
    CleanDirectory(publishDir);
	foreach (var project in projects)
	{
		CleanDirectory(dockerDir + Directory(project.Value.ToLower()) + Directory("app"));
	}
});

Task("Restore")
.IsDependentOn("Clean")
  .Does(() =>
{
 var settings = new DotNetCoreRestoreSettings
     {
         Sources  = new[]
		 {
            "https://api.nuget.org/v3/index.json",
            "https://www.myget.org/F/imageprocessor/api/v3/index.json",
			"https://www.myget.org/F/easynetq-unstable/api/v3/index.json"
		 }
     };

    DotNetCoreRestore("./PicFlow.sln", settings);
});

Task("Build")
    .IsDependentOn("Restore")
  .Does(() =>
{
   var settings = new DotNetCoreBuildSettings
    {
         Framework = "netcoreapp1.0",
         Configuration = configuration,
         OutputDirectory = "./artifacts/"
    };

	foreach (var project in projects)
	{
		var path = "./src/" + project.Key + "/";
		DotNetCoreBuild(path, settings);
	}
});

Task("Publish")
    .IsDependentOn("Build")
  .Does(() =>
{
    var settings = new DotNetCorePublishSettings
    {
         Framework = "netcoreapp1.0",
         Configuration = configuration
    };

	foreach (var project in projects)
	{
		settings.OutputDirectory = publishDir + Directory(project.Key);
		var path = "./src/" + project.Key + "/";
		DotNetCorePublish(path, settings);
	}
});

Task("Compression")
    .IsDependentOn("Publish")
  .Does(() =>
{
	foreach (var project in projects)
	{
		var filename = project.Key.ToLower() + ".tar.gz";
		var folder = dockerDir + Directory(project.Value.ToLower()) + Directory("app");
		GZipCompress(publishDir + Directory(project.Key.ToLower()), folder + File(filename), 9);
	}
    
});

Task("DockerBuild")
    .IsDependentOn("Compression")
  .Does(() =>
{
	foreach (var project in projects)
	{
		var folder = dockerDir + Directory(project.Value.ToLower());
		var tag = "fpommerening/msrmq:" + project.Value;
		var settings = new DockerBuildSettings
		{
			File = folder + File("Dockerfile.local"),
			Tag = new [] { tag }
		};
		DockerBuild(settings, folder);
	}
});


//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("DockerBuild");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);