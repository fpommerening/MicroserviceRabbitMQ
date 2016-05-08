using System;

namespace FP.MsRmq.ProcessChain.MarketPartner.Modules
{
    public class IncomingMessage
    {
        public DateTime Timestamp { get; set; }

        public string Content { get; set; }
    }
}
