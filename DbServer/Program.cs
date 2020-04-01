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
            Repository repository = new Repository("ChannelsFromMedia2",300);
            repository.CheckNewData();

            Console.ReadLine();
        }
    }
}
