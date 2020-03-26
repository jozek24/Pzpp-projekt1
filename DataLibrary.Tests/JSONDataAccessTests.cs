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
        private string Path = @"D:\Pzpp\Projekt 1\DataLibrary.Tests\TestObjects\Boks.xml";

        [Fact]
        public void GetListOfXmlDocument_IsValid()
        {
            var result = XmlDocuments(Path);

            List<string> actual = _JSONDataAccess.SerializeXMLToJSONlist(result);

            Assert.True(actual.Count > 0);
        }

        [Theory]
        [InlineData("xmls")]
        public void GetMatchCollection_Invalid(string param)
        {
            List<XmlDocument> result = new List<XmlDocument>();

            Assert.Throws<ArgumentException>(param, () => _JSONDataAccess.SerializeXMLToJSONlist(result));
        }

        public List<XmlDocument> XmlDocuments(string path)
        {
            List<XmlDocument> xmlDocuments = new List<XmlDocument>();
            xmlDocuments.Add(new XmlDocument());
            xmlDocuments[0].Load(path);
            return xmlDocuments;
        }

        [Fact]
        public void DeserializeJSONToList_IsValid()
        {
            List<string> result = _JSONDataAccess.SerializeXMLToJSONlist(XmlDocuments(Path));

            var actual = _JSONDataAccess.DeserializeJSONToList(result);

            Assert.True(actual.Count > 0);
        }
    }
}
