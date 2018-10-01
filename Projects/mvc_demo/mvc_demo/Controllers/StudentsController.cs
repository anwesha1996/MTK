using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_demo.Models;

namespace mvc_demo.Controllers
{
    public class StudentsController : Controller
    {
        StudentContext stdContext = new StudentContext();
        // GET: Students
        public ActionResult Index()
        {
            stdContext.Students.ToList();
            stdContext.Streams.ToList();
            return View();
        }
    }
}