using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Model
{
	public class Xml
	{
		[JsonProperty("__invalid_name__@version")]
		public string __invalid_name__version { get; set; }
		[JsonProperty("__invalid_name__@encoding")]
		public string __invalid_name__encoding { get; set; }
	}
}
