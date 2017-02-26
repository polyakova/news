using System.Collections.Generic;
using Newtonsoft.Json;

namespace News.Api.Models
{
	public class Sources
	{
		public string Status { get; set; }

		[JsonProperty(PropertyName = "sources")]
		public IEnumerable<Source> Items { get; set; }
	}
}
