using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using FP.MsRmq.ProcessChain.Contracts.Common;

namespace FP.MsRmq.ProcessChain.Contracts.Invoic
{
    public class Bill : InvoicMessage
    {
        [Required]
        public string Number { get; set; }

        [Required]
        public DateTime DocumentDate { get; set; }

        [Required]
        public string CustomerNumber { get; set; }

        public Collection<Position> Positions { get; set; }

        public Address Address { get; set; }
    }
}
