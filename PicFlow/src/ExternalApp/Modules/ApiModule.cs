using System.IO;
using FP.MsRMQ.PicFlow.ExternalApp.Data;
using FP.MsRMQ.PicFlow.ExternalApp.Models;
using Nancy;
using Nancy.ModelBinding;

namespace FP.MsRMQ.PicFlow.ExternalApp.Modules
{
    public class ApiModule : NancyModule
    {
        public ApiModule(EntryRepository repo) : base("/api")
        {
            Post("/postimage", async args =>
            {
                var apiUpload = this.Bind<ApiUpload>();

                if (apiUpload.ApiKey.ToLower() != "usergrouptour")
                {
                    return HttpStatusCode.Unauthorized;
                }

                if (apiUpload.Image != null)
                {

                    byte[] imageBytes;
                    using (var memoryStream = new MemoryStream())
                    {
                        var bytes = new byte[16 * 1024];
                        int count;
                        while ((count = apiUpload.Image.Value.Read(bytes, 0, bytes.Length)) > 0)
                        {
                            memoryStream.Write(bytes, 0, count);
                        }
                        imageBytes = memoryStream.ToArray();

                        await repo.SaveEntry(imageBytes, apiUpload.Image.Name,apiUpload.Message, apiUpload.User);
                    }
                }

                return HttpStatusCode.OK;
            });
        }
    }
}
