using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Model
{
    public class RssChannel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public List<Article> Article { get; set; }
    }
}
