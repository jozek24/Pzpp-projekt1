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

        public XMLDataAccess(List<string> urls)
        {
            foreach (var url in urls)
            {
                xmlDocuments.Add(new XmlDocument());
            }
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
