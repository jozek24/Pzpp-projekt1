using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace MediaReviewer.Model
{
    public class Channel
    {
        //[BsonElement("title")]
        public string Title { get; set; }
        //[BsonElement("link")]
        public string Link { get; set; }
        //[BsonElement("description")]
        public string Description { get; set; }
        //[BsonElement("language")]
        public string Language { get; set; }
        //[BsonElement("pubDate")]
        public string PubDate { get; set; }
        //[BsonElement("webMaster")]
        public string WebMaster { get; set; }
        //[BsonElement("docs")]
        public string Docs { get; set; }
        //[BsonElement("ttl")]
        public string Ttl { get; set; }
        //[BsonElement("image")]
        public Image Image { get; set; }
        //[BsonElement("item")]
        public List<Item> Item { get; set; }

    }
}
