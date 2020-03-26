using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Model
{
    public class Article
    {
        private IHTMLDataAccess _HTMLDataAccess = new HTMLDataAccess();

        public string Title { get; set; }
        public string Link { get; set; }

        public string HTML { get; set; }

        public List<string> Category { get; set; }

        public string PubDate { get; set; }


        public List<Article> GetArticles(RootObject rootObject)
        {
            List<Article> articles = new List<Article>();
            foreach (var item in rootObject.rss.Channel.Item)
            {
                articles.Add(
                    new Article 
                    { 
                        Title = item.Title, 
                        Link = item.Link, 
                        HTML = _HTMLDataAccess.GetHTML(item.Link), 
                        Category = item.Category, 
                        PubDate = item.PubDate 
                    });
            }
            return articles;
        }

        public List <Article> GetArticle(Item item)
        {
            return new List<Article> { new Article
            {
                Title = item.Title,
                Link = item.Link,
                HTML = _HTMLDataAccess.GetHTML(item.Link),
                Category = item.Category,
                PubDate = item.PubDate
            }};
        }
    }
}
