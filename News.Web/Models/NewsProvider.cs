using System.Web.Configuration;
using News.Api;

namespace News.Web.Models
{
	public class NewsProvider
	{
		private static readonly string _apiKey = WebConfigurationManager.AppSettings["NewsApiClient"];

		private IClient _client;

		public virtual IClient Client
		{
			get 
			{
				if (_client != null)
					return _client;
				
				_client = new Client(_apiKey);

				return _client;		
			}
		}
	}
}