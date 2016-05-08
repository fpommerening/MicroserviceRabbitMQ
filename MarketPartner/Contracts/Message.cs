using System;
using System.ComponentModel.DataAnnotations;

namespace FP.MsRmq.ProcessChain.Contracts
{
    public class Message
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public virtual string Type { get; set; }
    }
}
