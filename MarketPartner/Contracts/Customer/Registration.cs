﻿using System;
using System.ComponentModel.DataAnnotations;
using FP.MsRmq.ProcessChain.Contracts.Common;

namespace FP.MsRmq.ProcessChain.Contracts.Customer
{
    public class Registration : CustomerMessage
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Title { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public Address DeliveryAddress { get; set; }

        public Address BillingAddress { get; set; }
    }
}
