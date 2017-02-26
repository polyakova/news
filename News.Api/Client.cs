using System;
using System.Threading.Tasks;
using News.Api.Models;
using Newtonsoft.Json;

namespace News.Api
{
	public class Client: IClient
	{
		private readonly string _url = "https://newsapi.org/";
		private string _apiKey;

		public Client(string apiKey)
		{
			_apiKey = apiKey;
		}

		public async Task<Articles> GetArticlesAsync(string source, Sort sort = Sort.Top)
		{
			if (string.IsNullOrEmpty(source))
				throw new ArgumentNullException("Parameter \"source\" is empty.");
				
			var builder = new UriBuilder(_url)
			{
				Path = "v1/articles",
				Query = $"source={source}&apiKey={_apiKey}"
			};

			var result = await new WebClient().GetDataAsync(builder.Uri);

			if (result.Success)
				return JsonConvert.DeserializeObject<Articles>(result.Json);

			throw new Exception($"Failed to get articles for source \"{source}\". Error: {result.Error}");
		}

		public async Task<Sources> GetSourcesAsync(string category = null, string country = null, string lang = "en")
		{
			var builder = new UriBuilder(_url)
			{
				Path = "v1/sources",
				Query = $"category={category}&country={country}&language={lang}&apiKey={_apiKey}"
			};

			var result = await new WebClient().GetDataAsync(builder.Uri);

			if (result.Success)
				return JsonConvert.DeserializeObject<Sources>(result.Json);

			throw new Exception($"Failed to get sources. Error: {result.Error}");
		}

		public Sources GetSources(string category = null, string country = null, string lang = "en")
		{
			var builder = new UriBuilder(_url)
			{
				Path = "v1/sources",
				Query = $"category={category}&country={country}&lang={lang}&apiKey={_apiKey}"
			};

			var result = new WebClient().GetData(builder.Uri);

			if (result.Success)
				return JsonConvert.DeserializeObject<Sources>(result.Json);

			throw new Exception($"Failed to get sources. Error: {result.Error}");
		}
	}
}
