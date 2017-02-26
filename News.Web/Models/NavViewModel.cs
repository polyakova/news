using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.Web.Models
{
	public class NavViewModel
	{
		public IEnumerable<string> Topics { get; set; }
		public string Topic { get; set; }
	}
}