using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataLibrary
{
    public interface IXMLDataAccess
    {
        List<XmlDocument> XmlDocuments { get; set; }
        List<XmlDocument> GetListOfXmlDocument(List<string> urls);
    }
}
