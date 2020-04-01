using DataLibrary.Interfaces;
using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataLibrary
{
    public  class Repository : IRepository
    {
        private IJSONDataAccess jSONDataAccess = new JSONDataAccess();
        private RssChannel _rssChannel = new RssChannel();
        private Article _article = new Article();
       
		MongoCRUD db = new MongoCRUD("NowaBaza");
        private static Timer aTimer;

        public Repository()
		{
            var channelsfromdatabase = db.LoadRecords<RssChannel>("RssChannel").GetAwaiter().GetResult();
            AddNewRssChannels(channelsfromdatabase);
        }


        public void CheckNewData()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(600000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private  void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var channelsfromdatabase = db.LoadRecords<RssChannel>("RssChannel").GetAwaiter().GetResult();

            AddNewRssChannels(channelsfromdatabase);
            Console.WriteLine("Hello  ");
        }

        public void AddNewRssChannels(List<RssChannel>rssChannels)
        {
            if (rssChannels.Count > 0)
            {
                jSONDataAccess.RootObjects.ForEach(x =>
                {
                    if (!(rssChannels.Where(o => o.Link.ToString() == (x.rss.Channel.Link.ToString())).Any()))
                    {
                        db.InsertOneRecord<RssChannel>("RssChannel", _rssChannel.GetRssChannelFromRootObject(x)).GetAwaiter().GetResult();
                    }
                    else
                    {
                        x.rss.Channel.Item.ForEach(q =>
                        {
                            if (!rssChannels.Where(p => p.Articles.Where(l => l.Link == (q.Link)).Any()).Any())
                            {
                                var obj = _article.GetArticle(q);
                                db.AddNewArticle(x.rss.Channel.Link, obj.Link, obj).GetAwaiter().GetResult();
                            }
                        });
                    }
                });
            }
            else
            {
                throw new ArgumentException("You don't have data in rssChannels", "rssChannels");
            }
        }
    }
}
