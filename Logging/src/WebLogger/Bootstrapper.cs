using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace FP.MsRmq.Logging.WebLogger
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
          
            base.ApplicationStartup(container, pipelines);
        }
    }
}
