using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Model
{
    public class Article
    {
        public string Title { get; set; }
        public string Link { get; set; }

        public string HTML { get; set; }

        public List<string> Category { get; set; }

        public string PubDate { get; set; }
    }
}
