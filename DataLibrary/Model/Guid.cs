using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLibrary.Model
{
	public class Guid
	{
		[JsonProperty("__invalid_name__@isPermaLink")]
		public string __invalid_name__isPermaLink { get; set; }
		[JsonProperty("__invalid_name__#text")]
		public string __invalid_name__text { get; set; }
	}
}
