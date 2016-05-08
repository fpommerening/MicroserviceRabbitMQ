using System;
using System.ComponentModel.DataAnnotations;

namespace FP.MsRmq.ProcessChain.Contracts.Invoic
{
    public class Reversal : InvoicMessage
    {
        [Required]
        public string Number { get; set; }

        [Required]
        public DateTime DocumentDate { get; set; }

        [Required]
        public string ReferenceBillNumber { get; set; }

        [Required]
        public DateTime ReferenceDate { get; set; }
    }
}
