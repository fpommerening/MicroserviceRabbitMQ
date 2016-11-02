using System;
using System.Security.Claims;
using System.Security.Principal;
using EasyNetQ;
using FP.MsRMQ.PicFlow.Contracts;
using FP.MsRMQ.PicFlow.Contracts.FileHandler;
using FP.MsRMQ.PicFlow.WebApp.Modules;
using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;

namespace FP.MsRMQ.PicFlow.WebApp
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
            var bus = RabbitHutch.CreateBus(EnvironmentVariable.GetValueOrDefault("ConnectionStringRabbitMQ", "host=localhost"));
            container.Register<IBus>(bus);
            container.Register(new ImageRepository(EnvironmentVariable.GetValueOrDefault("ConnectionStringImageDB",
                "host=localhost;database=msrmq;password=leipzig;username=msrmq")));
            var authenticationRepository = new AuthenticationRepository(bus);
            container.Register<AuthenticationRepository>(authenticationRepository);
            container.Register<IFileHandler, MongoDbFileHandler>(new MongoDbFileHandler(EnvironmentVariable.GetValueOrDefault("ConnectionStringDocumentDB", "mongodb://localhost")));

            base.ApplicationStartup(container, pipelines);
        }

      

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            var configuration = new StatelessAuthenticationConfiguration(nancyContext =>
            {
                var authRepo = container.Resolve<AuthenticationRepository>();
                var authCookie = nancyContext.Request.Cookies.ContainsKey("picflow_webapp_apiKey") ? nancyContext.Request.Cookies["picflow_webapp_apiKey"] : string.Empty;
                Guid sessionId;
                if (!string.IsNullOrEmpty(authCookie) && Guid.TryParse(authCookie, out sessionId))
                {
                    var authUser = authRepo.GetAuthUserBySessionId(sessionId);
                    if (authUser != null && !authUser.IsEmpty() && authUser.IsValid)
                    {
                        return new ClaimsPrincipal(new GenericIdentity(authUser.Id.ToString(), "stateless"));
                    }
                }
                return null;
            });


            StatelessAuthentication.Enable(pipelines, configuration);
        }
    }
}
