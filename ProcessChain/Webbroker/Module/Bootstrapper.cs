using Nancy;
using Nancy.Authentication.Basic;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace FP.MsRmq.ProcessChain.Webbroker.Module
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            pipelines.EnableBasicAuthentication(new BasicAuthenticationConfiguration(
                container.Resolve<IUserValidator>(),"MyRealm"));
        }
    }
}
