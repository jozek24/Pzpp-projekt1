using DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbServer
{
    class Program
    {
        static void Main(string[] args)
        {
            JSONDataAccess jSONDataAccess = new JSONDataAccess();
            foreach (var rssChannel in jSONDataAccess.RssChannels)
            {
                Console.WriteLine(rssChannel.Title);
                Console.WriteLine(rssChannel.Link);
                foreach (var article in rssChannel.Articles)
                {
                    Console.WriteLine(article.Title);
                    Console.WriteLine(article.Link);
                    Console.WriteLine(article.PubDate);
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine(article.HTML);
                    Console.WriteLine("------------------------------------------------------------------------------");

                }
                Console.WriteLine("------------------------------------------------------------------------------");
            }
        }
    }
}
