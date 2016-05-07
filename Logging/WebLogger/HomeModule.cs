using Nancy;

namespace FP.MsRmq.Weblogger
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hallo Spartakiade 2016";
        }
    }
}
