using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMVC.Models;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private DBConnecter connecter=new DBConnecter();
        public async Task<IActionResult> Index()
        {
            return View(await connecter.CampusMinds.ToListAsync());

        }

        public ActionResult Create()
        {
            return View(new Mind());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Mind mind)
        {
            if (ModelState.IsValid)
            {
                connecter.CampusMinds.Add(mind);
                await connecter.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mind);
        }

        public async Task<ActionResult> Details(string id)
        {
            if(id==null)
            {
                return new StatusCodeResult(500);
            }
            Mind mind = await connecter.CampusMinds.FindAsync(id);
            if(mind==null)
                return new StatusCodeResult(404);
            return (View(mind));
        }
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new StatusCodeResult(500);
            }
            Mind mind = await connecter.CampusMinds.FindAsync(id);
            if (mind == null)
                return new StatusCodeResult(404);
            return (View(mind));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Mind mind)
        {
            if (ModelState.IsValid)
            {
                
                var current = connecter.CampusMinds.Where(m => m.MID == mind.MID).First();
                await connecter.SaveChangesAsync();
                current.Name = mind.Name;
                current.Track = mind.Track;

                await connecter.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mind);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
