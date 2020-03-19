using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLibrary.Model
{
	public class Item
	{
		public string Title { get; set; }
		public string Link { get; set; }
		public string Comments { get; set; }
		public HTML HTML { get; set; }
		public Guid Guid { get; set; }
		public List<string> Category { get; set; }
		public Description Description { get; set; }
		public string PubDate { get; set; }
	}
}
