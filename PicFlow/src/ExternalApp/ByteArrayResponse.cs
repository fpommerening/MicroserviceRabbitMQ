using System.IO;
using Nancy;

namespace FP.MsRMQ.PicFlow.ExternalApp
{
    public class ByteArrayResponse : Response
    {
        public ByteArrayResponse(byte[] body, string contentType = null)
        {
            this.ContentType = contentType ?? "application/octet-stream";

            this.Contents = stream =>
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(body);
                }
            };
        }
    }
}
