using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataLibrary
{
    public interface IJSONDataAccess
    {
        List<RootObject> RootObjects { get; set; }
        List<string> SerializeXMLToJSONlist(List<XmlDocument> xml);
        List<RootObject> DeserializeJSONToList(List<string> json);
    }
}
