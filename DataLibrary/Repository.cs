using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
   public  class Repository
    {
        private IJSONDataAccess jSONDataAccess = new JSONDataAccess();
        private RssChannel _rssChannel = new RssChannel();
        private Article _article = new Article();
       
		MongoCRUD db = new MongoCRUD("testowanieWDzien");//nazwa bazy
		public Repository()
		{
            List<RootObject> root = jSONDataAccess.DeserializeJSONToList(new List<string>());
            List<RssChannel> rssChannel = new List<RssChannel>();
            rssChannel.Add(new RssChannel()
            {
                Title = root[0].rss.Channel.Title,
                Link = "dfjkldjlf",

                Articles = new List<Article>
                {
                    new Article
                    {
                        Title = "tytuł1",
                        HTML = "tekst1",
                        Link = "link1",
                        PubDate = "d",
                    },
                    new Article
                    {
                        Title = "tytuł2",
                        HTML = "tekst2",
                        Link = "link2",
                        PubDate = "d",
                    }
                }
            });
            rssChannel.Add(new RssChannel()
            {
                Title = "Tytuł art 2",
                Link = "dfkljdflkf",
                Articles = new List<Article>
                {
                    new Article
                    {
                        Title = "tytuł3",
                        HTML = "tekst3",
                        Link = "link3",
                        PubDate = "d",
                    },
                    new Article
                    {
                        Title = "tytuł3",
                        HTML = "tekst3",
                        Link = "link3",
                        PubDate = "d",
                    }
                }
            });
            db.InsertRecord("RssChannel",rssChannel);//tworzenie dokładnej kolekcji jaką chcemy z nazwą

		}

       
        public void AddArticles(RootObject rootObject)
        {
            foreach (var article in jSONDataAccess.RootObjects)
            {
                if (true)
                {
                    db.InsertRecord("Article", _article.GetArticle(article.rss.));
                }
            }

        }
        public void AddRssChannels(List<RssChannel>rssChannels)
        {
            
            foreach (var rootObject in jSONDataAccess.RootObjects)
            {
                if (!(rssChannels.FindAll(r=>r.Link.Equals(rootObject.rss.Channel.Link)).Any()))
                {
                    db.InsertRecord("RssChannel", _rssChannel.GetRssChannelFromRootObject(rootObject));
                   
                }
                else
                {
                    AddArticles(rootObject);

                }
            }
          
        }



    }
}
