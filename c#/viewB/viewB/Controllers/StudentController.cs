using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using viewB.Models;

namespace viewB.Controllers
{
    public class StudentController : Controller
    {
		// GET: Student
			IList<Student> studentList = new List<Student>() {
					new Student(){ StudentID=1, StudentName="Steve", Age = 21 },
					new Student(){ StudentID=2, StudentName="Bill", Age = 25 },
					new Student(){ StudentID=3, StudentName="Ram", Age = 20 },
					new Student(){ StudentID=4, StudentName="Ron", Age = 31 },
					new Student(){ StudentID=5, StudentName="Rob", Age = 19 }
				};
			// GET: Student
			public ActionResult Index()
			{
				ViewBag.TotalStudents = studentList.Count();

				return View();
			}

		

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
