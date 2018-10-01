using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF.Models;

namespace EF.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
		Person p = new Person();
			p.Name = "anwesha";
			p.Age = 12;
            return View();
        }
    }
}