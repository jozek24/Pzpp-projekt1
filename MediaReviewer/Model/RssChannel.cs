using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace MediaReviewer.Model
{

    public class RssChannel
    {
        [BsonId] public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public List<Article> Articles { get; set; }
    }
}
