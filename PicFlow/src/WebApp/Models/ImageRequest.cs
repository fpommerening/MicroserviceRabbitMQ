using System.Collections.Generic;
using Nancy;

namespace FP.MsRMQ.PicFlow.WebApp.Models
{
    public class ImageRequest
    {
        public ImageRequest()
        {
            Resolutions = new List<int>();
        }

        public HttpFile File { get; set; }

        public string EventOverlay { get; set; }

        public List<int> Resolutions { get; set; }

        public string Message { get; set; }

        public bool PostImage { get; set; }
    }
}
