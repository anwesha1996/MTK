using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc_demo.Models;

namespace mvc_demo.Controllers
{
    public class MindsController : Controller
    {
        private TESTEntities1 db = new TESTEntities1();

        // GET: Minds
        public ActionResult Index(string searchName)
        {
            var minds = from m in db.Minds
                        select m;
            if(!string.IsNullOrEmpty(searchName))
            {
                minds = db.Minds.Where(m => m.FirstName.Contains(searchName));
            }
            return View(minds);
        }

        // GET: Minds/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mind mind = db.Minds.Find(id);
            if (mind == null)
            {
                return HttpNotFound();
            }
            return View(mind);
        }

        // GET: Minds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Minds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mind_Id,FirstName,LastName,Age,Gender,Batch,Address")] Mind mind)
        {
            if (ModelState.IsValid)
            {
                db.Minds.Add(mind);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mind);
        }

        // GET: Minds/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mind mind = db.Minds.Find(id);
            if (mind == null)
            {
                return HttpNotFound();
            }
            return View(mind);
        }

        // POST: Minds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mind_Id,FirstName,LastName,Age,Gender,Batch,Address")] Mind mind)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mind).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mind);
        }

        // GET: Minds/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mind mind = db.Minds.Find(id);
            if (mind == null)
            {
                return HttpNotFound();
            }
            return View(mind);
        }

        // POST: Minds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mind mind = db.Minds.Find(id);
            db.Minds.Remove(mind);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
