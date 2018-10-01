using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookMyRoom.BusinessLayer;
using BookMyRoom.Entitites;
using System.Web.Http.Description;

namespace BookMyRoom_WebAPI.Controllers
{
	public class UserDetailsController : ApiController
	{
		UserDetailsManager usermanager = new UserDetailsManager();

	   // POST: api/UserDetails
	   [HttpPost]
		[ResponseType(typeof(UserDetails))]
		public int PostUserDetail(UserDetails userDetails)
		{
			//try
			//{

			//	db.UserDetails.Add(userDetails);
			//	db.SaveChanges();
			//}
			//catch (Exception e)
			//{
			//	return 0;
			//}
			//return 1;

			int result = usermanager.SaveUserDetail(userDetails);
			return result;
		}
	}

}

		

	