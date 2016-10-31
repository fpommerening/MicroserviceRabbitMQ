using System.IO;
using System.Threading.Tasks;
using FP.MsRMQ.PicFlow.Contracts.Dto;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace FP.MsRMQ.PicFlow.Contracts.FileHandler
{
    public class MongoDbFileHandler : IFileHandler
    {
        private readonly string _mongoConnectionString;

        private static readonly object syncRootMapRegister = new object();

        public MongoDbFileHandler(string mongoConnectionString)
        {
            _mongoConnectionString = mongoConnectionString;
        }

        public async Task<FileUploadResult> HandleUpload(string fileName, Stream inputStream)
        {
          
            var dtoImages = new DtoImage();
            var bytes = new byte[16 * 1024];
            using (var memoryStream = new MemoryStream())
            {
                int count;
                while ((count = inputStream.Read(bytes, 0, bytes.Length)) > 0)
                {
                    memoryStream.Write(bytes, 0, count);
                }
                dtoImages.Data = memoryStream.ToArray();
            }
            dtoImages.FileName = fileName;
            return new FileUploadResult {Identifier  = await SaveMessageObject(dtoImages) };
            
        }

        public async Task<string> SaveMessageObject<T>(T msg) where T : class
        {
            var db = GetMongoDatabase();
            var collection = db.GetCollection<DtoMessage>("Messages");
            var dto = new DtoMessage {Object = msg};
            await collection.InsertOneAsync(dto);
            return dto.Id.ToString();
        }

        public async Task<T> GetMessageObject<T>(string msgId) where T : class
        {
            lock (syncRootMapRegister)
            {
                if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
                {
                    BsonClassMap.RegisterClassMap<T>();
                }
            }

            var objectCollection = GetMongoDatabase().GetCollection<DtoMessage>("Messages");
            var dbMessageObject = await objectCollection.Find(x => x.Id == new ObjectId(msgId)).FirstOrDefaultAsync();
            return (T)dbMessageObject?.Object;
        }

        public void RegisterTypeForDeserialization<T>()
        {
            lock (syncRootMapRegister)
            {
                if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
                {
                    BsonClassMap.RegisterClassMap<T>();
                }
            }
        }


        private IMongoDatabase GetMongoDatabase()
        {
            var client = new MongoClient(_mongoConnectionString);
            return client.GetDatabase("PicFlowData");
        }
    }
}
