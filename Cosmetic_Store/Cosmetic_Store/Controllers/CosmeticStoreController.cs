using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuisnessLayer;
using EntityLayer;

namespace Cosmetic_Store.Controllers
{
    public class CosmeticStoreController : Controller
    {
	 private readonly CosmeticStoreManager cosmeticStoreManager = new CosmeticStoreManager();
		// GET: BookStore
		public ActionResult Index(CosmeticDetails cosmeticDetails)
		{

			List<CosmeticDetails> cDetails = cosmeticStoreManager.GetDetails();


			IEnumerable<CosmeticDetails> details = cDetails.Cast<CosmeticDetails>().Select(detail => detail);

			return View(details);
		}
		

        // GET: CosmeticStore/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CosmeticStore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CosmeticStore/Create
      
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Cos_ID,Cos_Title,Company,Category,Quantity,Price")] CosmeticDetails cosmeticDetails)
		{


			// TODO: Add insert logic here
			if (ModelState.IsValid)
			{
				cosmeticStoreManager.SaveCosDetail(cosmeticDetails);
				return RedirectToAction("Index", cosmeticDetails);
			}


			return View(cosmeticDetails);

		}

        // GET: CosmeticStore/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

		// POST: CosmeticStore/Edit/5
		[HttpPost]
		public ActionResult Edit([Bind(Include = "Cos_ID,Cos_Title,Company,Category,Quantity,Price")] CosmeticDetails cosmeticDetails)
		{
			if (ModelState.IsValid)
			{
				cosmeticStoreManager.UpdateDetails(cosmeticDetails);
				return RedirectToAction("Index");
			}
			return View(cosmeticDetails);
		}

        // GET: CosmeticStore/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CosmeticStore/Delete/5
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
