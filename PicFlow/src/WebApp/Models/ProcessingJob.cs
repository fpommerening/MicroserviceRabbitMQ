using System;

namespace FP.MsRMQ.PicFlow.WebApp.Models
{
    public class ProcessingJob
    {
        public DateTime Timestamp { get; set; }

        public Guid JobId { get; set; }

        public string Filename { get; set; }

        public string Message { get; set; }

        public bool CalcRes2 { get; set; }

        public Guid IdRes2 { get; set; }

        public bool CalcRes3 { get; set; }

        public Guid IdRes3 { get; set; }

        public bool CalcRes6 { get; set; }

        public Guid IdRes6 { get; set; }

        public bool CalcRes12 { get; set; }

        public Guid IdRes12 { get; set; }
    }
}
