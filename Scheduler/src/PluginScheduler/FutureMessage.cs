using System;

namespace FP.MsRmq.PluginScheduler
{
    public class FutureMessage
    {
        public FutureMessage()
        {
            Timestamp = DateTime.Now;
        }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
