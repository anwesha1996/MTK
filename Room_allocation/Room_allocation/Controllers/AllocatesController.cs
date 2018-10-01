using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Room_allocation.Models;

namespace Room_allocation.Controllers
{
    public class AllocatesController : Controller
    {
        private UserContext db = new UserContext();

        // GET: Allocates
        public ActionResult Index()
        {
            var allocates = db.Allocates.Include(a => a.Room).Include(a => a.User);
            return View(allocates.ToList());
        }

        // GET: Allocates/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Allocate allocate = db.Allocates.Find(id);
        //    if (allocate == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(allocate);
        //}

        // GET: Allocates/Create//one user has booked two rooms more than that u have already booked.
        public ActionResult Create()
        {
			//var rooms = (from a in db.Allocates select a.RoomId).ToList();
			//var urooms = (from b in db.Rooms where !rooms.Contains(b.RoomId) select b).ToList();
			var user = (from a in db.Allocates select a.Uid).ToList();
			//var uuser = (from b in db.Users where !user.Contains(b.Uid) select b).ToList();
			//ViewBag.RoomId = new SelectList(urooms, "RoomId", "Rid");
			//ViewBag.Uid = new SelectList(uuser, "Uid", "Mid");
			
			//var user = (from a in db.Allocates group a by a.Uid into g where g.Count() > 2 select g.Key).ToList();
			//var uuser = (from b in db.Users where !user.Contains(b.Uid) select b.Uid).ToList();
			
			var rooms = (from a in db.Allocates select a.RoomId).ToList();
			var urooms = (from b in db.Rooms where !rooms.Contains(b.RoomId) select b).ToList();
			ViewBag.RoomId = new SelectList(urooms, "RoomId", "Rid");
		    ViewBag.Uid = new SelectList(db.Users, "Uid", "Mid");




			return View();
        }

        // POST: Allocates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "A_Id,Uid,RoomId")] Allocate allocate)
        {
            if (ModelState.IsValid)
            {
				try
				{

					int u = allocate.Uid;
					int c = (from b in db.Allocates where b.Uid.Equals(u) select b).Count();
					if (c < 2)
					{

						db.Allocates.Add(allocate);
						db.SaveChanges();
						return RedirectToAction("Index");
					}
					else
					{
						TempData["message"] = "You cannot book more than 2 rooms";
						return RedirectToAction("Create","Allocates");


					}
				}
				catch (Exception e)
				{
					return View("Exception");
					
                    
				}

            }
			 ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Rid", allocate.RoomId);
			ViewBag.Uid = new SelectList(db.Users, "Uid", "Mid", allocate.Uid);

			// ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Block_name", allocate.RoomId);
			//ViewBag.Uid = new SelectList(db.Users, "Uid", "Mid", allocate.Uid);
			return View(allocate);
        }

        // GET: Allocates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocate allocate = db.Allocates.Find(id);
            if (allocate == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Rid", allocate.RoomId);
            ViewBag.Uid = new SelectList(db.Users, "Uid", "Mid", allocate.Uid);
            return View(allocate);
        }

        // POST: Allocates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "A_Id,Uid,RoomId")] Allocate allocate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allocate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Rid", allocate.RoomId);
			ViewBag.Uid = new SelectList(db.Users, "Uid", "Mid", allocate.Uid);
			
            return View(allocate);
        }

        // GET: Allocates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocate allocate = db.Allocates.Find(id);
            if (allocate == null)
            {
                return HttpNotFound();
            }
            return View(allocate);
        }

        // POST: Allocates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Allocate allocate = db.Allocates.Find(id);
            db.Allocates.Remove(allocate);
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
