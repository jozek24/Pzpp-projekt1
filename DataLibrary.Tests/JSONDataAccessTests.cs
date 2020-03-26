using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace DataLibrary.Tests
{
    public class JSONDataAccessTests
    {
        private IXMLDataAccess _XMLDataAccess = new XMLDataAccess();
        private IJSONDataAccess _JSONDataAccess = new JSONDataAccess();
        
        [Fact]
        public void GetListOfXmlDocument_IsValid()
        {
            List<XmlDocument> xmlDocuments = new List<XmlDocument>();
            xmlDocuments.Add(new XmlDocument());
            xmlDocuments[0].Load(@"D:\Pzpp\Projekt 1\DataLibrary.Tests\TestObjects\Boks.xml");

            List<string> actual = _JSONDataAccess.SerializeXMLToJSONlist(xmlDocuments);
            Assert.True(actual.Count > 0);
        }
    }
}
