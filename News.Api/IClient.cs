using System.Threading.Tasks;
using News.Api.Models;

namespace News.Api
{
	public interface IClient
	{
		Task<Articles> GetArticlesAsync(string source, Sort sort = Sort.Top);
		Task<Sources> GetSourcesAsync(string category = null, string country = null, string lang = "en");
		Sources GetSources(string category = null, string country = null, string lang = "en");
	}
}
