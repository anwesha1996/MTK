using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMathInput.Controllers
{
    public class SimpleMathInputController : Controller
    {
		// GET: SimpleMathInput

		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Index()
		{
			return View();

		}
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Index(SimpleMathInputController o)
		{
			return View(o);
		}
	}
}