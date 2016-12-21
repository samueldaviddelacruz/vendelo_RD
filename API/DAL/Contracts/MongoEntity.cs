using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.DAL{

public abstract class MongoEntity
{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { set; get; }
    
    
   
   
   
}
}