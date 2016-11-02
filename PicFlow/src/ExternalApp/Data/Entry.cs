using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FP.MsRMQ.PicFlow.ExternalApp.Data
{
    public class Entry
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("image")]
        public byte[] Image { get; set; }

        [BsonElement("filename")]
        public string Filename { get; set; }

        [BsonElement("username")]
        public string UserName { get; set; }

        [BsonElement("message")]
        public string Message { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
