using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class HTMLDataAccess : IHTMLDataAccess
    {
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
            throw new NotImplementedException();
        }
    }
}
