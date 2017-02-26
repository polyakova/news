using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using News.Api;
using News.Api.Models;
using News.Web.Controllers;

namespace News.Web.Test
{
	[TestClass]
	public class NewsControllerTest
	{
		[TestMethod]
		public async Task SourcesReturnsValidResult()
		{
			var sources = new Sources
			{
				Status = "ok",
				Items = new List<Source>() { new Source
				{
					Category = "technology",
					Id = "ars-technica",
					Name = "Ars Technica",
					Url = "http://arstechnica.com"
				}}
			};

			var client = new Mock<IClient>();
			client.Setup(x => x.GetSourcesAsync(null, null, "en")).Returns(Task.FromResult(sources));
			
			var controller = new NewsController(client.Object);

			var result = await controller.Sources();

			Assert.AreEqual(sources.Items.First().Id, result.Items.First().Id);
		}

		[TestMethod]
		public async Task ArticlesReturnsListOfArticlesForAllTopics()
		{
			var sources = TestHelper.GetMockedSources();
			var articles = TestHelper.GetMockedArticles();

			var client = new Mock<IClient>();
			client.Setup(x => x.GetSourcesAsync(null, null, "en")).Returns(Task.FromResult(sources));
			
			client.Setup(x => x.GetArticlesAsync("ars-technica", Sort.Top)).Returns(Task.FromResult(new Articles
			{
				Items = new List<Article>() { articles[0] }
			}));

			client.Setup(x => x.GetArticlesAsync("associated-press", Sort.Top)).Returns(Task.FromResult(new Articles
			{
				Items = new List<Article>() { articles[1] }
			}));

			var controller = new NewsController(client.Object);
			var result = await controller.Articles(null);

			Assert.AreEqual(articles[0].Title, result[0].Items.First().Title);
			Assert.AreEqual(articles[1].Title, result[1].Items.First().Title);
		}

		[TestMethod]
		public async Task ArticlesReturnsListOfArticlesForSpecificTopic()
		{
			var sources = TestHelper.GetMockedSources();
			var articles = TestHelper.GetMockedArticles();

			var client = new Mock<IClient>();
			client.Setup(x => x.GetSourcesAsync(null, null, "en")).Returns(Task.FromResult(sources));

			client.Setup(x => x.GetArticlesAsync("ars-technica", Sort.Top)).Returns(Task.FromResult(new Articles
			{
				Items = new List<Article>() { articles[0], articles[2] }
			}));

			var controller = new NewsController(client.Object);
			var result = await controller.Articles("technology");

			Assert.AreEqual(articles[0].Title, result[0].Items.First().Title);
			Assert.AreEqual(articles[2].Title, result[0].Items.Last().Title);
		}		
	}
}
