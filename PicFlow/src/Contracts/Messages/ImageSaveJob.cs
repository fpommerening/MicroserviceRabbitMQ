using System;

namespace FP.MsRMQ.PicFlow.Contracts.Messages
{
    public class ImageSaveJob : ImageJob
    {
        public string SourceId { get; set; }

        public Guid UserId { get; set; }

        public string Message { get; set; }

        public int Resolution { get; set; }
    }
}
