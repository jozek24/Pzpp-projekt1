using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataLibrary.Tests
{
    public class HTMLDataAccessTests
    {
        private HTMLDataAccess _HTMLDataAccess = new HTMLDataAccess();
        private string _URL = "https://media2.pl/rss";

        public void GetHTML_ValidURL(string url)
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead(url)) ;
                string actual = _HTMLDataAccess.GetHTML(url);
                Assert.True(!String.IsNullOrEmpty(actual));
            }
            catch (Exception)
            {
                Assert.Throws<ArgumentException>("Url, connection", () => _HTMLDataAccess.GetHTML(""));
            }
        }
    }
}
