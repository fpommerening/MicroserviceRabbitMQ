using System;

namespace FP.MsRMQ.PicFlow.ExternalApp.Models
{
    public class ImageItem
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Message { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
