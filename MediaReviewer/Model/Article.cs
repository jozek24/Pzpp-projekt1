using System.Collections.Generic;

namespace MediaReviewer.Model
{
    public class Article
    {
            public string Title { get; set; }
            public string Link { get; set; }
            public string HTML { get; set; }
            public List<string> Category { get; set; }
            public string PubDate { get; set; }
    }
}
