using System;
using System.Collections.Generic;

namespace FP.MsRMQ.PicFlow.Contracts.Dbo
{
    public class ProcessingJob
    {
        public DateTime Timestamp { get; set; }

        public Guid Id { get; set; }

        public string SourceId { get; set; }

        public Guid UserId { get; set; }

        public string Message { get; set; }

        public List<Image> Images { get; set; }

        public string Filename { get; set; }
    }
}
