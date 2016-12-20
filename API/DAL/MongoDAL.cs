using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.DAL
{
    public class MongoDAL<T> where T : MongoEntity
    {
        //static readonly string constring = "mongodb://10.0.0.21:27017";
        static readonly string constring = "mongodb://ingsamy:mega007@ds059519.mlab.com:59519/mongolabdb";

        static readonly string dbname = "mongolabdb";

        private static MongoClient _client;
       
        private static IMongoDatabase _database;
        
        static IMongoDatabase GetDb()
        {
            return _database ?? (_database = GetClient().GetDatabase(dbname));
        }

        static IMongoClient GetClient()
        {
            return _client ?? (_client = new MongoClient(constring));
        }



        public async Task<List<T>> GetAll()
        {
        
            var collection = GetDb().GetCollection<T>(typeof(T).Name).AsQueryable();

            return await collection.ToListAsync();
        }

        public async Task Insert(T entity)
        {
            var collection = GetDb().GetCollection<T>(typeof(T).Name);
            await collection.InsertOneAsync(entity);
        }

        public async Task<T> FindByObjectId(ObjectId id){
            var collection = GetDb().GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("_id",id);
            var result = await collection.Find(filter).FirstAsync();

            return result;
        }

        public async Task<T> FindByExpression(Expression<Func<T, bool>> filter){
            var collection = GetDb().GetCollection<T>(typeof(T).Name);
            var result = await collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task<T> FindByObjectIdString(string id){

            return await FindByObjectId(ObjectId.Parse(id));

        }

    }




}