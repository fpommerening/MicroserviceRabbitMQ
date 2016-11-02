using Nancy;

namespace FP.MsRMQ.PicFlow.ExternalApp.Models
{
    public class ApiUpload
    {
        public string ApiKey { get; set; }

        public HttpFile Image { get; set; }

        public string Message { get; set; }

        public string User { get; set; }

    }
}
