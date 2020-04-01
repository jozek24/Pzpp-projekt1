
using DataLibrary.Interfaces;
using DataLibrary.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class MongoCRUD : IMongoCRUD
    {
        private IMongoDatabase db;

		public MongoCRUD(string database) //chyba połączenie do bazy
		{
			var client = new MongoClient();
			db = client.GetDatabase(database);
		}
		public void InsertRecord<T>(string table, List<T> record)
		{
			var collection = db.GetCollection<T>(table);//tworzenie kolekcji gengerycznej
			collection.InsertMany(record); //wstawia wiele rekord
		}

		public async Task InsertOneRecord<T>(string table, T record) where T : class
		{
			var collection = db.GetCollection<T>(table);
			await collection.InsertOneAsync(record);
		}
		public async Task<List<T>> LoadRecords<T>(string table)
		{
			var collection = db.GetCollection<T>(table);
			return await collection.FindSync(new BsonDocument()).ToListAsync();
		}

		public async Task AddNewArticle(string linkRootObject, string linkArticle, Article article)
		{
			var collection = db.GetCollection<RssChannel>("RssChannel");
			var filter = Builders<RssChannel>.Filter.Where(x => x.Link == linkRootObject);
			var update = Builders<RssChannel>.Update.Push(x => x.Articles, article);
			await collection.FindOneAndUpdateAsync(filter, update);
		}

    }
}
