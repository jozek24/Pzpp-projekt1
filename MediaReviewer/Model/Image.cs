using MongoDB.Bson.Serialization.Attributes;

namespace MediaReviewer.Model
{
    public class Image
    {
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("url")]
        public string Url { get; set; }
        [BsonElement("link")]
        public string Link { get; set; }
        [BsonElement("width")]
        public string Width { get; set; }
        [BsonElement("height")]
        public string Height { get; set; }

    }
}
