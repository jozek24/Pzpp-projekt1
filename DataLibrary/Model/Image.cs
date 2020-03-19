using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLibrary.Model
{
	public class Image
	{
		public string Title { get; set; }
		public string Url { get; set; }
		public string Link { get; set; }
		public string Width { get; set; }
		public string Height { get; set; }
	}
}
