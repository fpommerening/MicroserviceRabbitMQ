using System;
using System.IO;
using System.Threading.Tasks;

namespace FP.MsRMQ.PicFlow.Contracts.FileHandler
{
    public class LocalStorageFileHandler
    {
        public async Task<FileUploadResult> HandleUpload(string fileName, System.IO.Stream stream)
        {
            string uuid = GetFileName();
            string targetFile = GetTargetFile(uuid);

            using (FileStream destinationStream = File.Create(targetFile))
            {
                await stream.CopyToAsync(destinationStream);
            }

            return new FileUploadResult()
            {
                Identifier = uuid
            };
        }

        private string GetTargetFile(string fileName)
        {
            return Path.Combine(GetUploadDirectory(), fileName);
        }

        private string GetFileName()
        {
            return Guid.NewGuid().ToString();
        }

        private string GetUploadDirectory()
        {
            var uploadDirectory = "c:\\temp\\images";

            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            return uploadDirectory;
        }
    }
}
