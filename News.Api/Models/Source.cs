using System.Collections.Generic;
using Newtonsoft.Json;

namespace News.Api.Models
{
	public class Source
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public string Category { get; set; }
		public string Language { get; set; }
		public string Country { get; set; }

		[JsonProperty("urlsToLogos")]
		public Dictionary<string, string> Logos { get; set; }

		[JsonProperty("sortBysAvailable")]
		public IEnumerable<Sort> Sort { get; set; }
	}
}
