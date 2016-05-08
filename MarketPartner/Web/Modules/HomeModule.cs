using Nancy;

namespace FP.MsRmq.ProcessChain.MarketPartner.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                return View["home"];
            };

            Get["/functions/"] = _ =>
            {
                return View["functions"];
            };
        }
    }
}
