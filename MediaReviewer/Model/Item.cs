using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace MediaReviewer.Model
{
    class Item
    {
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("link")]
        public string Link { get; set; }
        [BsonElement("comments")]
        public string Comments { get; set; }
        [BsonElement("guid")]
        public Guid Guid { get; set; }
        [BsonElement("category")]
        public List<string> Category { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("pubDate")]
        public string PubDate { get; set; }
    }
}
