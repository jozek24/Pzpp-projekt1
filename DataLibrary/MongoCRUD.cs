
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database) // połączenie do bazy
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }
        public void InsertRecord<T>(string table, List<T> record)
        {
            var collection = db.GetCollection<T>(table);//tworzenie kolekcji generycznej
            collection.InsertMany(record); //wstawia wiele rekord
        }
        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

    }
}
