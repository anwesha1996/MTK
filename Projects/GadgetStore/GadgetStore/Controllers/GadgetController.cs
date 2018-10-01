using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetStore.Models;


namespace GadgetStore.Controllers
{
    
    public class GadgetController : Controller
    {
        private GadgetStoreDBContext Context = new GadgetStoreDBContext();
        
        // GET: Gadget
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllProducts()
        {

            try
            {
                List<Gadget> gadgetList;
                gadgetList = Context.Gadgets.ToList();
                return View(gadgetList);
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
                return View("Error");
            }
        }

        public ActionResult AddGadget()
        {
            
                return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddGadget(Gadget gadget)
        {
            if (ModelState.IsValid)
            {
                Context.Gadgets.Add(gadget);
                Context.SaveChanges();
                TempData["SuccessMessage"] = "Gadget details have been saved successfully";
                return RedirectToAction("GetAllProducts");

            }

            else
            {
                return View(gadget);
            }
        }

        public ActionResult GetWishList()
        {
            var wishList = Context.AddToWishlists.ToList();
            var gadgetWishList = new List<Gadget>();
            if (wishList.Any())
            {
                foreach (var item in wishList)
                {
                    var gadget = Context.Gadgets.Find(item.GadgeID);
                    gadgetWishList.Add(gadget);
                }

            }
            return View(gadgetWishList);
        }


        public ActionResult AddToWishList(int id)
        {
            var wishListItem = Context.AddToWishlists.Where(list => list.GadgeID == id).FirstOrDefault();
            if (wishListItem == null)
            {
               
                AddToWishList wishListObj = new AddToWishList();
               
                wishListObj.GadgeID = id;
                Context.AddToWishlists.Add(wishListObj);
                Context.SaveChanges();
            }

            return RedirectToAction("GetWishList");
        }

        //public string GetWishListId()
        //{
        //    var wishList = Context.AddToWishlists.ToList();
        //    var wishlistID = "";

        //    List<int> arrayOfIDs = new List<int>();
        //    if (wishList.Any())
        //    {
        //        foreach (var item in wishList)
        //        {
        //            var id = item.WishListID;
        //            arrayOfIDs.Add(Convert.ToInt32(id));
        //        }

        //        wishlistID = Convert.ToString(arrayOfIDs.Max() + 1);

        //    }
        //    else
        //    {
        //        wishlistID = Convert.ToString(1000);
        //    }
        //    return wishlistID;
        //}
        
        public ActionResult DeleteGadgetFromWishList(int id)
        {

           var wishListItem = Context.AddToWishlists.Where(list => list.GadgeID == id).FirstOrDefault();
            Context.AddToWishlists.Remove(wishListItem);
            Context.SaveChanges();
            return RedirectToAction("GetWishList");
        }
    }
}