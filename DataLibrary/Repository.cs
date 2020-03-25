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
		MongoCRUD db = new MongoCRUD("testowanieWDzien");//nazwa bazy
		public Repository()
		{
            List<RssChannel> rssChannel = new List<RssChannel>();
            rssChannel.Add(new RssChannel()
            {
                Title = "tytuł art 1",
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

       
        public void AddArticles()
        {
            

        }
        public void AddRssChannels()
        {

            var rssChannels = db.LoadRecords<RssChannel>("RssChannel");

        }



    }
}
