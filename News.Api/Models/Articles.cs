using System.Collections.Generic;
using Newtonsoft.Json;

namespace News.Api.Models
{
	public class Articles
	{
		public string Status { get; set; }
		public string Source { get; set; }

		[JsonProperty("sortBy")]
		public Sort Sort { get; set; }

		[JsonProperty("articles")]
		public IEnumerable<Article> Items { get; set; }
	}
}
