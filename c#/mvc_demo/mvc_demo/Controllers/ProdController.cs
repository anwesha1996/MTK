using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_demo.Controllers
{
	[RoutePrefix("prod")]
	public class ProdController : Controller
	{

	    [Route]
		public ActionResult  Index()
		{
			return View();
		}


		[Route("{id?}")]
		public ActionResult Details(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				ViewBag.message = "details method";
				return View();
			}
			ViewBag.message = "done";
			return View();
		}
	}
}