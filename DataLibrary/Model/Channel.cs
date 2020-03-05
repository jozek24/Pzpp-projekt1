using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLibrary.Model
{
	[XmlRoot(ElementName = "channel")]
	public class Channel
	{
		[XmlElement(ElementName = "title")]
		public string Title { get; set; }
		[XmlElement(ElementName = "link")]
		public string Link { get; set; }
		[XmlElement(ElementName = "description")]
		public string Description { get; set; }
		[XmlElement(ElementName = "language")]
		public string Language { get; set; }
		[XmlElement(ElementName = "pubDate")]
		public string PubDate { get; set; }
		[XmlElement(ElementName = "webMaster")]
		public string WebMaster { get; set; }
		[XmlElement(ElementName = "docs")]
		public string Docs { get; set; }
		[XmlElement(ElementName = "ttl")]
		public string Ttl { get; set; }
		[XmlElement(ElementName = "image")]
		public Image Image { get; set; }
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; }
	}
}
