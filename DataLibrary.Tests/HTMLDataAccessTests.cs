using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace DataLibrary.Tests
{
    public class HTMLDataAccessTests
    {
        private HTMLDataAccess _HTMLDataAccess = new HTMLDataAccess();
        private string _URL = "https://media2.pl/rss";
        private string _html = "https://media2.pl/rss/tag/jesien-2016.xml";

        [Fact]
        public void GetHTML_ValidURL()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead(_URL)) ;
                string actual = _HTMLDataAccess.GetHTML(_URL);
                Assert.True(!String.IsNullOrEmpty(actual));
            }
            catch (Exception)
            {
                Assert.Throws<ArgumentException>("Url, connection", () => _HTMLDataAccess.GetHTML(""));
            }
        }

        [Theory]
        [InlineData("Invalid", "Url")]
        public void GetHTML_InvalidURL(string url, string param)
        {
            Assert.Throws<ArgumentException>(param, () => _HTMLDataAccess.GetHTML(url));
        }

        [Theory]
        [InlineData("", "Url, connection")]
        public void GetHTML_WithoutURLOrConnectionLost(string url, string param)
        {
            Assert.Throws<ArgumentException>(param, () => _HTMLDataAccess.GetHTML(url));
        }

        [Fact]
        public void GetMatchCollection_ShoutWork()
        {
            MatchCollection actual = _HTMLDataAccess.GetMatchCollection(_html);
            Assert.True(actual.Count > 0);
        }

        [Theory]
        [InlineData("aaaa", "html")]
        public void GetMatchCollection_ShoutFail(string html, string param)
        {
            Assert.Throws<ArgumentException>(param, () => _HTMLDataAccess.GetMatchCollection(html));
        }

        [Fact]
        public void AddNewURLForXML_ShoutWork()
        {
            MatchCollection match = _HTMLDataAccess.GetMatchCollection(_html);
            List<string> actual = _HTMLDataAccess.AddNewURLForXML(match);
            Assert.True(actual.Count > 0);
        }
    }
}
