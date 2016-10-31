using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FP.MsRMQ.PicFlow.ExternalApp.Data
{
    public class EntryRepository
    {
        private readonly string _mongoConnectionString;

        public EntryRepository(string mongoConnectionString)
        {
            _mongoConnectionString = mongoConnectionString;
        }

        public async Task SaveEntry(byte[] image, string filename, string message, string username)
        {
            var entry = new Entry
            {
                Image = image,
                Message = message,
                Timestamp = DateTime.Now,
                UserName = username,
                Filename = filename
            };

            var db = GetMongoDatabase();
            var collection = db.GetCollection<Entry>("Entries");
            await collection.InsertOneAsync(entry);
        }

        public async Task<long> GetEntriesCount()
        {
            var db = GetMongoDatabase();
            var collection = db.GetCollection<Entry>("Entries");
            var filter = new BsonDocument();
            return await collection.CountAsync(filter);
        }

        public async Task<Entry> GetEntryById(string id)
        {
            var objectCollection = GetMongoDatabase().GetCollection<Entry>("Entries");
            return await objectCollection.Find(x => x.Id == new ObjectId(id)).FirstOrDefaultAsync();
        }

        public async Task<List<Entry>> GetEntries(int startIndex, int limit)
        {
            var objectCollection = GetMongoDatabase().GetCollection<Entry>("Entries");
            var filter = new BsonDocument();
            var sort = Builders<Entry>.Sort.Ascending("timestamp");
            return await objectCollection.Find(filter).Sort(sort).Skip(startIndex - 1).Limit(limit).ToListAsync();
        }

        private IMongoDatabase GetMongoDatabase()
        {
            var client = new MongoClient(_mongoConnectionString);
            return client.GetDatabase("ExtAppData");
        }

    }
}
