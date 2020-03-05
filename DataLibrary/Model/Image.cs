using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLibrary.Model
{
	[XmlRoot(ElementName = "image")]
	public class Image
	{
		[XmlElement(ElementName = "title")]
		public string Title { get; set; }
		[XmlElement(ElementName = "url")]
		public string Url { get; set; }
		[XmlElement(ElementName = "link")]
		public string Link { get; set; }
		[XmlElement(ElementName = "width")]
		public string Width { get; set; }
		[XmlElement(ElementName = "height")]
		public string Height { get; set; }
	}
}
