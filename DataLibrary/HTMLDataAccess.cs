using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class HTMLDataAccess : IHTMLDataAccess
    {
        private string Url = "https://media2.pl/rss";
        public List<string> ListOfXMLURL { get; set; }
        public HTMLDataAccess()
        {
        }

        public void GetFirstData()
        {
            var html = GetHTML(Url);
            ListOfXMLURL = GetListOfXMLURL(html);
        }
        public string GetHTML(string url)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string htmlCode = client.DownloadString(url);
                    return htmlCode;
                }
                catch (WebException)
                {
                    throw new ArgumentException("You pasted invalid parameter", "Url");
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("You don't pasted parameter or connection lost", "Url, connection");
                }
            }
        }

        public List<string> GetListOfXMLURL(string html)
        {
            MatchCollection mcol = GetMatchCollection(html);
            List<string> output = AddNewURLForXML(mcol);
            return output;
        }

        public MatchCollection GetMatchCollection(string html)
        {
            MatchCollection mcol = Regex.Matches(html, @"https://media2.pl/rss/tag/\b\S+?\bxml");
            if (mcol.Count == 0)
                throw new ArgumentException("There is no phrase in the text", "html");

            return mcol;
        }

        public List<string> AddNewURLForXML(MatchCollection match)
        {
            List<string> output = new List<string>();
            if (match.Count == 0)
                throw new ArgumentException("There is no match", "match");

            match.Cast<Match>().ToList().ForEach(x =>
                {
                    if (!output.Contains(x.Value))
                    {
                        output.Add(x.Value);
                    }
                }
            );
            return output;
        }
        
    }
}
