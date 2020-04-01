using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataLibrary.Tests
{
    public static class XMLMethods
    {
        public static List<XmlDocument> XmlDocuments(string path)
        {
            List<XmlDocument> xmlDocuments = new List<XmlDocument>();
            xmlDocuments.Add(new XmlDocument());
            xmlDocuments[0].Load(path);
            return xmlDocuments;
        }
    }
}
