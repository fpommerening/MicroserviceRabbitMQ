using System;

namespace FP.MsRmq.Cluster.Contracts
{
    public class ClusterMessage
    {
        public string Message { get; set; }

        public string Host { get; set; }

        public DateTime Timestamep { get; set; }
    }
}
