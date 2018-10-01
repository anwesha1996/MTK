using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UserRegAPI.Models;

namespace UserRegAPI.Controllers
{
    public class AccountController : ApiController
    {
		[Route("api/User/Register")]
		[HttpPost]
		public IdentityResult Register(AccountModel model)
		{
			var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
			var manager = new UserManager<ApplicationUser>(userStore);
			var user = new ApplicationUser { Name = model.Name, Email = model.Email };
			user.Gender = model.Gender;
			user.Age = model.Age;
			user.Mobile_no = model.Mobile_no;
			IdentityResult result = manager.Create(user, model.Password);
			return result;


		}

    }
}
