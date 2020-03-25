using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataLibrary
{
    public class XMLDataAccess : IXMLDataAccess
    {
        private List<XmlDocument> xmlDocuments = new List<XmlDocument>();

        HTMLDataAccess _HTMLDataAccess = new HTMLDataAccess();

        public List<XmlDocument> XmlDocuments { get; set; }

        public XMLDataAccess()
        {

            _HTMLDataAccess.GetFirstData();
            foreach (var url in _HTMLDataAccess.ListOfXMLURL)
            {
                xmlDocuments.Add(new XmlDocument());
            }
            XmlDocuments = GetListOfXmlDocument(_HTMLDataAccess.ListOfXMLURL);
        }

        public List<XmlDocument> GetListOfXmlDocument(List<string> urls)
        {
            int n = 0;
            foreach (var document in xmlDocuments)
            {
                document.Load(urls[n]);
                n++;
            }
            return xmlDocuments;
        }
    }
}
