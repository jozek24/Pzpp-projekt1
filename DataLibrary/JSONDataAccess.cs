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
        private IXMLDataAccess _XMLDataAccess = new XMLDataAccess();

        public List<RootObject> RootObjects { get; set; }

        public JSONDataAccess()
        {
            var serialize = SerializeXMLToJSONlist(_XMLDataAccess.XmlDocuments);
            RootObjects = DeserializeJSONToList(serialize);
        }

        public List<RootObject> DeserializeJSONToList(List<string> json)
        {
            if (json.Count > 0)
            {
                try
                {
                    return json.Select(x => JsonConvert.DeserializeObject<RootObject>(x)).ToList();
                }
                catch (Exception)
                {
                    throw new ArgumentException("You passed invalid JSONs for deserialize", "jsons");
                }
            }

            throw new ArgumentException("You pasted empty list of JSON", "jsons");
        }

        public List<string> SerializeXMLToJSONlist(List<XmlDocument> xmls)
        {
            if(xmls.Count > 0 )
                return xmls.Select(x => $"{JsonConvert.SerializeXmlNode(x)}").ToList();
            
            throw new ArgumentException("You pasted empty list of XmlDocument", "xmls");
        }
    }
}
