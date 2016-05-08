using Nancy;

namespace FP.MsRmq.ProcessChain.Webbroker.Module
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Spartakiade 2016 ProcessChain Webbroker";
        }
    }
}
