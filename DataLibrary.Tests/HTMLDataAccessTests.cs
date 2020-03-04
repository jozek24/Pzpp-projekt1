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
        [InlineData("", "Url, connection")]
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
    }
}
