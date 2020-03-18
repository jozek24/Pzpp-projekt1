using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace MediaReviewer.Model
{
    class Rss
    {
       // [BsonElement("channel")]
      //  public Channel Channel { get; set; }

        [BsonElement("version")]
        public string Version { get; set; }

    }
}
