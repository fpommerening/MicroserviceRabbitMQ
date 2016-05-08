using System;

namespace FP.MsRmq.ProcessChain.MarketPartner.Models
{
    public class Reversal : Request
    {
        public string Number { get; set; }

        public DateTime DocumentDate { get; set; }

        public string ReferenceBillNumber { get; set; }

        public DateTime ReferenceDate { get; set; }
    }
}
