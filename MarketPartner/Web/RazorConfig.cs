using System.Collections.Generic;
using Nancy.ViewEngines.Razor;

namespace FP.MsRmq.ProcessChain.MarketPartner
{
    public class RazorConfig : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            return null;
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            return null;
        }

        public bool AutoIncludeModelNamespace
        {
            get { return false; }
        }
    }
}
