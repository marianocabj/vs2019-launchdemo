using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VS2019LaunchDemoFinale.Models
{
	public class Liga
	{
		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("clubs", NullValueHandling = NullValueHandling.Ignore)]
		public List<Club> Clubs { get; set; }
	}
}
