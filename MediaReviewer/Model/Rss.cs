using MongoDB.Bson.Serialization.Attributes;

namespace MediaReviewer.Model
{
    public class Rss
    {
        //[BsonElement("channel")]
        public Channel Channel { get; set; }
        //[BsonElement("version")]
        public string Version { get; set; }

    }
}
