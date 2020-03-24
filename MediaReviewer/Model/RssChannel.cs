using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace MediaReviewer.Model
{

    public class RssChannel
    {
            public string Title { get; set; }
            public string Link { get; set; }
            public List<Article> Articles { get; set; }
    }
}
