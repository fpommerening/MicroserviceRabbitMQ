﻿using System;
using System.Collections.Generic;

namespace FP.MsRmq.ProcessChain.Data.Objects
{
    public class BOBill
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public DateTime DocumentDate { get; set; }

        public BOCustomer Customer { get; set; }

        public List<BOPosition> Positions { get; set; }

        public BOAddress Address { get; set; }
        
    }
}
