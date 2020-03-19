using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Model
{
	public class RootObject
	{
		[JsonProperty("__invalid_name__?xml")]
		public Xml __invalid_name__xml { get; set; }
		public Rss rss { get; set; }
	}
}
