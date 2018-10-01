using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UserAPI.Models;
using System.Web.Http.Cors;

namespace UserAPI.Controllers
{
	//[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserDetailsController : ApiController
    {
        private UserContext db = new UserContext();

        // GET: api/UserDetails
		[HttpGet]
        public IQueryable<UserDetail> GetUserDetails()
        {
            return db.UserDetails;
        }

		[HttpGet]
		// GET: api/UserDetails/5
		[Route("api/getuser")]
        [ResponseType(typeof(UserDetail))]
        public IHttpActionResult GetUserDetail(int id)
        {
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return NotFound();
            }

            return Ok(userDetail);
        }

        // PUT: api/UserDetails/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUserDetail(UserDetail userDetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }


        //    db.Entry(userDetail).State = EntityState.Modified;

          
        //        db.SaveChanges();
           
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserDetailExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/UserDetails
        [ResponseType(typeof(UserDetail))]
		//     public int PostUserDetail(UserDetail userDetail)
		//     {


		//try
		//{

		//	db.UserDetails.Add(userDetail);
		//	db.SaveChanges();
		//}
		//catch (Exception e)
		//{
		//	return 0;C:\Users\M1047281\Documents\Visual Studio 2017\Projects\UserAPI\UserAPI\Controllers\UserDetailsController.cs
		//}
		//return  1;
		//     }
		[HttpPost]
		public IHttpActionResult PostUserDetail(UserDetail userDetail)
		{
	
			db.UserDetails.Add(userDetail);
			db.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = userDetail.Uid }, userDetail);
		}


		//[Route("api/search")]
		//[HttpPost]
		//public IHttpActionResult search(UserDetail user)
		//{


		//	var q = from UserDetail in db.UserDetails
		//			where UserDetail.Name == user.Name
		//			select UserDetail;


		//		return Ok();


		//}
		[Route("api/search")]
		[HttpPost]
		public bool search(UserDetail user)
		{
			var q = from UserDetail in db.UserDetails
					where UserDetail.Name == user.Name
					
					select UserDetail;
			

			if (q.Any())
			{

				return true;
			}
			else
			{
				
				return false;
			}


		}



		// DELETE: api/UserDetails/5
		[ResponseType(typeof(UserDetail))]
        public IHttpActionResult DeleteUserDetail(int id)
        {
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return NotFound();
            }

            db.UserDetails.Remove(userDetail);
            db.SaveChanges();

            return Ok(userDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserDetailExists(int id)
        {
            return db.UserDetails.Count(e => e.Uid == id) > 0;
        }

    }
}