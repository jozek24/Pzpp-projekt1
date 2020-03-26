using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataLibrary.Interfaces
{
    interface IRepository
    {
        void CheckNewData();
        void OnTimedEvent(Object source, ElapsedEventArgs e);
        void AddNewRssChannels(List<RssChannel> rssChannels);
    }
}
