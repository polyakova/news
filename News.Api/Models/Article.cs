using System;
using Newtonsoft.Json;

namespace News.Api.Models
{
	public class Article
	{
		public string Author { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }

		[JsonProperty("urlToImage")]
		public string Image { get; set; }

		[JsonProperty("publishedAt", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime Published { get; set; }
	}
}
