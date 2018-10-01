using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_demo.Models;

namespace mvc_demo.Controllers
{
    public class NorthwindController : Controller
    {
        NorthWindContext db = new NorthWindContext();
        // GET: Northwind
        public ActionResult Index()
        {
            db.CategoriesTable.ToList();
            db.Products.ToList();
            return View();
        }
    }
}