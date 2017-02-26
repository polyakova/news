using System.Linq;
using System.Net;
using System.Web.Mvc;
using News.Api;
using News.Web.Models;

namespace News.Web.Controllers
{
	public class HomeController : Controller
	{
		private IClient _client;

		public HomeController(IClient client)
		{
			_client = client;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Header(string id)
		{
			return PartialView(new NavViewModel
			{
				Topics = _client.GetSources().Items.Select(s => s.Category).Distinct().ToList(), // it's not possible to call async child actions, so it should be synchronous here
				Topic = id
			});
		}

		public ActionResult Topic(string id)
		{
			if (string.IsNullOrEmpty(id))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			return View("index", model: id); 
		}
	}
}