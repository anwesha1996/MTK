using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace event_management1.Controllers
{
	public class Homeafter_LoginController : Controller
	{
		// GET: Homeafter_Login
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult MyEvents()
		{
			return View();
		}
		public ActionResult CreateEvents()
		{
			return View();
		}
	}
}