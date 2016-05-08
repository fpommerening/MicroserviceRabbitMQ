using System;

namespace FP.MsRmq.ProcessChain.Data.Objects
{
    public class BOReversal
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public DateTime DocumentDate { get; set; }

        public BOBill ReferenceBill { get; set; }

    }
}
