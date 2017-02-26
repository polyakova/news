using System.Collections.Generic;
using News.Api.Models;

namespace News.Web.Test
{
	internal static class TestHelper
	{
		public static Sources GetMockedSources()
		{
			var sources = new List<Source>();

			sources.Add(new Source
			{
				Category = "technology",
				Id = "ars-technica",
				Name = "Ars Technica",
				Url = "http://arstechnica.com"
			});

			sources.Add(new Source
			{
				Category = "general",
				Id = "associated-press",
				Name = "Associated Press",
				Url = "http://bigstory.ap.org"
			});

			sources.Add(new Source
			{
				Category = "sport",
				Id = "bbc-sport",
				Name = "BBC Sport",
				Url = "http://www.bbc.co.uk/sport"
			});

			return new Sources
			{
				Status = "ok",
				Items = sources
			};
		}

		public static List<Article> GetMockedArticles()
		{
			var articles = new List<Article>();

			articles.Add(new Article
			{
				Title = "Darwin’s Unfinished Symphony: How food and culture made the human mind"
			});

			articles.Add(new Article
			{
				Title = "Darwin’s Unfinished Symphony: How food and culture made the human mind"
			});

			articles.Add(new Article
			{
				Title = "Google Assistant comes to every Android phone, 6.0 and up"
			});

			return articles;
		}
	}
}
