using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;

namespace News.Web
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute("news-articles", "api/news/articles/{topic}", new { action = "articles", controller = "news", topic = UrlParameter.Optional });
			config.Routes.MapHttpRoute("news-sources", "api/news/sources", new { action = "sources", controller = "news"});

			var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
			jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

		}
	}
}
