using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MediaReviewer.Model
{
    public class ArticlesStorage : IArticlesStorage
    {
        private IMongoDatabase db;
        public ArticlesStorage(string databaseName)
        {
            var client = new MongoClient();
            db = client.GetDatabase(databaseName);
        }
        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}
