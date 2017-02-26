using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using News.Api;
using News.Web.Controllers;
using News.Web.Models;
using System.Linq;

namespace News.Web.Test
{
	[TestClass]
	public class HomeContollerTest
	{
		[TestMethod]
		public void TopicReturnsNotFoundResultOfIdIsNullOrEmpty()
		{
			var client = new Mock<IClient>();
			var controller = new HomeController(client.Object);
			var result = controller.Topic(null);

			Assert.IsInstanceOfType(result as HttpStatusCodeResult, typeof(HttpStatusCodeResult));

		}

		[TestMethod]
		public void TopicReturnsViewResult()
		{
			var client = new Mock<IClient>();
			var controller = new HomeController(client.Object);
			var result = controller.Topic("business");

			Assert.IsInstanceOfType(result as ViewResult, typeof(ViewResult));
			Assert.AreEqual((result as ViewResult).ViewName, "index");
		}

		[TestMethod]
		public void HeaderReturnsViewResult()
		{
			var client = new Mock<IClient>();
			client.Setup(x => x.GetSources(null, null, "en")).Returns(TestHelper.GetMockedSources());

			var controller = new HomeController(client.Object);
			var result = controller.Header("technology");

			Assert.IsInstanceOfType(result as PartialViewResult, typeof(PartialViewResult));
			Assert.AreEqual(((result as PartialViewResult).Model as NavViewModel).Topic, "technology");
			Assert.AreEqual(((result as PartialViewResult).Model as NavViewModel).Topics.ToList()[1], "general");
		}
	}
}
