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
        private IHTMLDataAccess _HTMLDataAccess = new HTMLDataAccess();
        private string _URL = @"C:\Users\Tomek\Documents\Pzpp-projekt1\DataLibrary.Tests\TestObjects\MainPage.html";
        private string _html = "https://media2.pl/rss/tag/jesien-2016.xml";

        /// <summary>
        /// The method checks if the GetHTML_ValidURL method returns a value with a valid URL.
        /// </summary>
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

        /// <summary>
        /// The method checks if the GetHTML() method returns an exception with an invalid URL.
        /// </summary>
        /// <param name="url">Invalid url</param>
        /// <param name="param">Exception parameter</param>
        [Theory]
        [InlineData("Invalid", "Url")]
        public void GetHTML_InvalidURL(string url, string param)
        {
            Assert.Throws<ArgumentException>(param, () => _HTMLDataAccess.GetHTML(url));
        }

        /// <summary>
        /// The method checks if the GetHTML() method returns an exception without internet connection.
        /// </summary>
        /// <param name="url">Invalid url</param>
        /// <param name="param">Exception parameter</param>
        [Theory]
        [InlineData("","Url, connection")]
        public void GetHTML_WithoutURLOrConnectionLost(string url, string param)
        {
            Assert.Throws<ArgumentException>(param, () => _HTMLDataAccess.GetHTML(url));
        }

        /// <summary>
        /// The method checks if the GetMatchCollection() method returns a value.
        /// </summary>
        [Fact]
        public void GetMatchCollection_ShoutWork()
        {
            MatchCollection actual = _HTMLDataAccess.GetMatchCollection(_html);
            Assert.True(actual.Count > 0);
        }

        /// <summary>
        /// The method checks if the GetMatchCollection() method method returns an exception with an invalid html.
        /// </summary>
        /// <param name="html">Invalid html</param>
        /// <param name="param">Exception parameter</param>
        [Theory]
        [InlineData("aaaa", "html")]
        public void GetMatchCollection_ShoutFail(string html, string param)
        {
            Assert.Throws<ArgumentException>(param, () => _HTMLDataAccess.GetMatchCollection(html));
        }

        /// <summary>
        /// The method checks if the AddNewURLForXML() method returns a value. 
        /// </summary>
        [Fact]
        public void AddNewURLForXML_ShoutWork()
        {
            MatchCollection match = _HTMLDataAccess.GetMatchCollection(_html);
            List<string> actual = _HTMLDataAccess.AddNewURLForXML(match);
            Assert.True(actual.Count > 0);
        }

        /// <summary>
        /// The method checks if the AddNewURLForXML() method method returns an exception with an invalid html.
        /// </summary>
        /// <param name="html">Invalid html</param>
        /// <param name="param">Exception parameter</param>
        [Theory]
        [InlineData("aaa", "match")]
        public void AddNewURLForXML_ShoutFail(string html, string param)
        {
            MatchCollection match = Regex.Matches(html, @"https://media2.pl/rss/tag/\b\S+?\bxml");
            Assert.Throws<ArgumentException>(param, () => _HTMLDataAccess.AddNewURLForXML(match));
        }
    }
}
