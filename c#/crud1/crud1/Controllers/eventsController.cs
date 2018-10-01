using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud1.Controllers
{
    public class eventsController : Controller
    {
        // GET: events
        public ActionResult Index()
        {
            return View();
        }
    }
}