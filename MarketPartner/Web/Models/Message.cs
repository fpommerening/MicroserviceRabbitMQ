using System;

namespace FP.MsRmq.ProcessChain.MarketPartner.Models
{
    public class Message
    {
        public DateTime Timestamp { get; set; }

        public string Content { get; set; }
    }
}
