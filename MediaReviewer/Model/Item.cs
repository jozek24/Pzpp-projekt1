using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace MediaReviewer.Model
{
    public class Item
    {
        //[BsonElement("title")]
        public string Title { get; set; }
        //[BsonElement("link")]
        public string Link { get; set; }
        //[BsonElement("comments")]
        public string Comments { get; set; }

        public HTML HTML { get; set; }
        //[BsonElement("guid")]
        public Guid Guid { get; set; }
        //[BsonElement("category")]
        public List<string> Category { get; set; }
        //[BsonElement("description")]
        public string Description { get; set; }
        //[BsonElement("pubDate")]
        public string PubDate { get; set; }
    }
}
