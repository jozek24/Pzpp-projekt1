using DataLibrary.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataLibrary
{
    public class JSONDataAccess : IJSONDataAccess
    {
        public List<RootObject> DeserializeJSONToList(List<string> json)
        {
            return json.Select(x => JsonConvert.DeserializeObject<RootObject>(x)).ToList();
        }

        public List<string> SerializeXMLToJSONlist(List<XmlDocument> xml)
        {
            return xml.Select(x => $"{JsonConvert.SerializeXmlNode(x)}").ToList();
        }
    }
}
