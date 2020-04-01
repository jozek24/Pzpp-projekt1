using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        /// <summary>
        /// This method give you a List of passed objects from database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}
