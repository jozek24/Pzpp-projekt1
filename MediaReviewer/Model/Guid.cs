using MongoDB.Bson.Serialization.Attributes;

namespace MediaReviewer.Model
{
    public class Guid
    {
        [BsonElement("isPermaLink")]
        public string IsPermaLink { get; set; }
        [BsonElement("text")]   //[XmlText]
        public string Text { get; set; }

    }
}
