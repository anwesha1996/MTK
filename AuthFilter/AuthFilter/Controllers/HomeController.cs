using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthFilter.Controllers
{
	
	public class HomeController : Controller
	{
		[OutputCache(Duration = 10)] //  Result Filter attribute

		public String Index()
		{
			//ViewBag.Title = "Home Page";

			return DateTime.Now.ToString("T");
		}


		//public ActionResult Index()
		//{
		//	return View();
		//}

		//public ActionResult About()
		//{
		//	return View();
		//}
	}
}