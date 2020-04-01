using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaReviewer.ViewModel
{
    public class RssChannel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public List<Article> Articles { get; set; }

        public RssChannel()
        {
            Title = "Test tytułu kanału";
            Articles = new List<Article>();
            for (int i = 0; i < 10; i++)
            {
                Article obj = new Article();
                Articles.Add(obj);
            }
        }
    }
}
