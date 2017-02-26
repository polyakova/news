using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Practices.Unity;
using News.Api;
using News.Api.Models;

namespace News.Web.Controllers
{
	public class NewsController : ApiController
	{
		//private IClient _client;

		[Dependency]
		public IClient _client { get; set; }

		public NewsController(IClient client) 
		{
			_client = client;
		}

		[HttpGet]
		public async Task<Sources> Sources()
		{
			return await _client.GetSourcesAsync();
		}

		[HttpGet]
		public async Task<Articles[]> Articles(string topic)
		{
			var sources = await _client.GetSourcesAsync();
			var topics = sources.Items.GroupBy(s => s.Category.ToLowerInvariant()).ToDictionary(g => g.Key, g => g.ToList());
			var tasks = Enumerable.Empty<Task<Articles>>();

			if (string.IsNullOrEmpty(topic))
				tasks = topics.Select(c => _client.GetArticlesAsync(c.Value.First().Id)).ToList();
			else
			{
				topic = topic.ToLowerInvariant();

				if (topics.ContainsKey(topic))
					tasks = topics[topic].Select(s => _client.GetArticlesAsync(s.Id));
			}

			return await Task.WhenAll(tasks);
		}
	}
}
