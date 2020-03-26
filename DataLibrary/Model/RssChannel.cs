
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
        private Article Article = new Article();
      
        [BsonId] 
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public List<Article> Articles { get; set; }

        public List<RssChannel> GetRssChannelFromRootObjects(List<RootObject> rootObjects)
        {
            List<RssChannel> rssChannels = new List<RssChannel>();
            foreach (var rootObject in rootObjects)
            {
                rssChannels.Add(
                    new RssChannel
                    { 
                        Title = rootObject.rss.Channel.Title, 
                        Link= rootObject.rss.Channel.Link, 
                        Articles = Article.GetArticles(rootObject) 
                    });
            }
            return rssChannels;
        }

        public List< RssChannel>  GetRssChannelFromRootObject(RootObject rootObject)
        {
            return new List<RssChannel>{new RssChannel
            {
                Title = rootObject.rss.Channel.Title,
                Link = rootObject.rss.Channel.Link,
                Articles = Article.GetArticles(rootObject)
            }};
            
        }
    }
}
