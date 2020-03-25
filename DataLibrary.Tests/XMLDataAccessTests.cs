using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace DataLibrary.Tests
{
    public class XMLDataAccessTests
    {
        private IHTMLDataAccess _HTMLDataAccess = new HTMLDataAccess();
        private IXMLDataAccess _XMLDataAccess = new XMLDataAccess();

        [Fact]
        public void GetListOfXmlDocument_ValidUrls()
        {
            //ToDo
            _HTMLDataAccess.GetHTML("");
            List<XmlDocument> actual = _XMLDataAccess.GetListOfXmlDocument(_HTMLDataAccess.ListOfXMLURL);
            Assert.True(actual.Count > 0);
        }
    }
}
