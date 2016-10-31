using System;
using System.IO;
using System.Threading.Tasks;
using FP.MsRMQ.PicFlow.Contracts.Dto;
using FP.MsRMQ.PicFlow.Contracts.FileHandler;

namespace FP.MsRMQ.PicFlow.ImagePersistor
{
    public class FileWriter
    {
        private readonly string _mongoConnectionString;
        public FileWriter(string mongoConnectionString)
        {
            _mongoConnectionString = mongoConnectionString;
        }

        public async Task PersistImage(string id)
        {
            var handler = new MongoDbFileHandler(_mongoConnectionString);
            var image = await handler.GetMessageObject<DtoImage>(id);

            using (var sourceStream = File.Open($"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}", FileMode.OpenOrCreate))
            {
                sourceStream.Seek(0, SeekOrigin.End);
                await sourceStream.WriteAsync(image.Data, 0, image.Data.Length);
            }
        }
    }
}
