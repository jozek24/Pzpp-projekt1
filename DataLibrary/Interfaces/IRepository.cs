using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataLibrary.Interfaces
{
    public interface IRepository
    {
        void CheckNewData();
        void AddNewRssChannels(List<RssChannel> rssChannels);
    }
}
