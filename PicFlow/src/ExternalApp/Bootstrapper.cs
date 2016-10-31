using System;
using System.Collections;
using FP.MsRMQ.PicFlow.ExternalApp.Data;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;

namespace FP.MsRMQ.PicFlow.ExternalApp
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("css", "css"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("img", "img"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("font", "font"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("js", "js"));
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            container.Register<EntryRepository>(new EntryRepository(GetEnvironmentVariableOrDefault("ConnectionStringEntryDB", "mongodb://localhost")));
            base.ApplicationStartup(container, pipelines);
        }

        public static string GetEnvironmentVariableOrDefault(string key, string defaultValue)
        {
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
            {
                if (de.Key?.ToString() == key)
                {
                    Console.WriteLine($"GetEnvVar {key} - {de.Value}");
                    return de.Value.ToString();
                }
            }
            Console.WriteLine($"GetEnvVar {key} - default - {defaultValue}");
            return defaultValue;
        }
    }
}
