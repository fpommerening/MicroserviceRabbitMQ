using System;

namespace FP.MsRmq.IoTApp.Contracts
{
  
        public class MeteringValue
        {
            public decimal Value { get; set; }

            public string ObisCode { get; set; }

            public DateTime Timestamp { get; set; }

            public string Host { get; set; }
        }
   
}
