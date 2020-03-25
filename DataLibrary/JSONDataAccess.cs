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
        private XMLDataAccess _XMLDataAccess = new XMLDataAccess();
        private RssChannel RssChannel = new RssChannel();

        public List<RssChannel> RssChannels { get; set; }
        public JSONDataAccess()
        {
            var serialize = SerializeXMLToJSONlist(_XMLDataAccess.XmlDocuments);
            var rootObjects = DeserializeJSONToList(serialize);
            RssChannels = RssChannel.GetRssChannelFromRootObject(rootObjects);
        }

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
