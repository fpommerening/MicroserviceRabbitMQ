using Nancy;

namespace FP.MsRmq.Logging.WebLogger
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => "Hello Developer Open Space 2016");
        }
    }
}
