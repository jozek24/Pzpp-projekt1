using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLibrary.Model
{
	[XmlRoot(ElementName = "item")]
	public class Item
	{
		[XmlElement(ElementName = "title")]
		public string Title { get; set; }
		[XmlElement(ElementName = "link")]
		public string Link { get; set; }
		[XmlElement(ElementName = "comments")]
		public string Comments { get; set; }
		[XmlElement(ElementName = "guid")]
		public Guid Guid { get; set; }
		[XmlElement(ElementName = "category")]
		public List<string> Category { get; set; }
		[XmlElement(ElementName = "description")]
		public string Description { get; set; }
		[XmlElement(ElementName = "pubDate")]
		public string PubDate { get; set; }
	}
}
