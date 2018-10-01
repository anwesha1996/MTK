using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAuthenticationDemo.Models;

namespace UserAuthenticationDemo.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Login login)
        {
            
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            else
            {
                if (login.UserName == "Rittik" && login.Password == "test1234")
                {
                    Session["UserID"] = Guid.NewGuid();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login attempt.");
                    return View(login);
                }
            }
        }
    }
}