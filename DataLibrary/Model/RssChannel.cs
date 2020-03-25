using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Model
{
    public class RssChannel
    {
        [BsonId] 
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public List<Article> Articles { get; set; }
    }
}
