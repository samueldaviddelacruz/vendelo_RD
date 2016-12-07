using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace API.DAL
{
    public class MongoDAL<T> where T : MongoEntity
    {
        static string constring = "mongodb://localhost:27017";
        
        static string dbname = "test_vendelo";
       
        static MongoClient client;
       
        static IMongoDatabase database;
        
        static IMongoDatabase GetDB(){
            if(database==null){
               database = GetClient().GetDatabase(dbname);
            }
            return database;
        }

        static IMongoClient GetClient(){
            if(client==null){
                client = new MongoClient(constring);
            }
            return client;
        }



        public async Task<List<T>> GetAll()
        {
        
            var collection = GetDB().GetCollection<T>(typeof(T).Name).AsQueryable();

            return await collection.ToListAsync();
        }

        public async Task Insert(T entity)
        {
            var collection = GetDB().GetCollection<T>(typeof(T).Name);
            await collection.InsertOneAsync(entity);
        }

        public async Task<T> FindByObjectID(ObjectId id){
            var collection = GetDB().GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("_id",id);
            var result = await collection.Find(filter).FirstAsync();
            return result;
        }
        
        public async Task<T> FindByObjectIDString(string id){

            return await FindByObjectID(ObjectId.Parse(id));

        }

    }




}