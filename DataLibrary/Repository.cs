using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataLibrary
{
   public  class Repository
    {
        private IJSONDataAccess jSONDataAccess = new JSONDataAccess();
        private RssChannel _rssChannel = new RssChannel();
        private Article _article = new Article();
       
		MongoCRUD db = new MongoCRUD("NowaBaza");//nazwa bazy
        private static Timer aTimer;

        public Repository()
		{
            var channelsfromdatabase = db.LoadRecords<RssChannel>("RssChannel");

            AddNewRssChannels(channelsfromdatabase);
		}
     

        public void CheckNewData()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private  void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var channelsfromdatabase = db.LoadRecords<RssChannel>("RssChannel");

            AddNewRssChannels(channelsfromdatabase);
            Console.WriteLine("Hello  ");
        }


        public void AddNewRssChannels(List<RssChannel>rssChannels)
        {

            foreach (var rootObject in jSONDataAccess.RootObjects)
            {
                if (!(rssChannels.FindAll(x => x.Link.Equals(rootObject.rss.Channel.Link)).Any()))
                {

                    db.InsertRecord("RssChannel", _rssChannel.GetRssChannelFromRootObject(rootObject));

                }

                foreach (var item in rootObject.rss.Channel.Item)
                {
                    if (rssChannels.FindAll(x => x.Articles.Equals(item.Link)).Any())
                    {
                        db.InsertRecord("Article", _article.GetArticle(item));
                    }
                }
            }
        }
    }
}
