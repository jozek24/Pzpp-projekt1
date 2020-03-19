using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLibrary.Model
{
	public class Rss
	{
		[JsonProperty("__invalid_name__@version")]
		public string __invalid_name__version { get; set; }
		public Channel Channel { get; set; }
	}
}
