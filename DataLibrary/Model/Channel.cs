using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLibrary.Model
{
	public class Channel
	{
		public string Title { get; set; }
		public string Link { get; set; }
		public string Description { get; set; }
		public string Language { get; set; }
		public string PubDate { get; set; }
		public string WebMaster { get; set; }
		public string Docs { get; set; }
		public string Ttl { get; set; }
		public Image Image { get; set; }
		public List<Item> Item { get; set; }
	}
}
