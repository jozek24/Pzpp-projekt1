﻿using DataLibrary.Model;
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

        public List<RootObject> RootObjects { get; set; }

        public JSONDataAccess()
        {
            var serialize = SerializeXMLToJSONlist(_XMLDataAccess.XmlDocuments);
            RootObjects = DeserializeJSONToList(serialize);
        }

        public List<RootObject> DeserializeJSONToList(List<string> json)
        {
            return json.Select(x => JsonConvert.DeserializeObject<RootObject>(x)).ToList();
        }

        public List<string> SerializeXMLToJSONlist(List<XmlDocument> xmls)
        {
            return xmls.Select(x => $"{JsonConvert.SerializeXmlNode(x)}").ToList();
        }
    }
}
