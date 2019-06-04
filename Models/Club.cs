using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VS2019LaunchDemoFinale.Models
{
	public class Club
	{
		[JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
		public string Key { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("code", NullValueHandling = NullValueHandling.Include)]
		public string Code { get; set; }
	}
}
