using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BookMyRoom.Controllers
{
    [CustomExceptionFilter]
    public class BookingHistoryController : ApiController
    {
        /// <summary>
        /// bookingHistoryManager is the object for BookingHistoryManager class
        /// </summary>
        private readonly BookingHistoryManager bookingHistoryManager = new BookingHistoryManager();
        /// <summary>
        /// Method to get BookingHistory of a particular Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> HttpActionResult</returns>
        [HttpGet]
        
        public IHttpActionResult BookingHistory(int id)
        {
           
           //Calling GetDetails Method which is in BusinessLayer by passing parameter "id"
            List<History> history = bookingHistoryManager.GetDetails(id);
            try
            {
                
                
              return Ok(history);
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

       /// <summary>
       /// Cancelling BookingHistory with BookingId
       /// </summary>
       /// <param name="bookingid"></param>
       /// <returns></returns>
        [HttpDelete]
        [Route("api/BookingHistory/Cancel/{bookingid}")]
        public IHttpActionResult CancelBooking(int bookingid)
        {
            //Checking if bookingid is less than 1
            if (bookingid < 1)
            {
                // If bookingid is less than 1 ArgumentNullException Can be thrown
                throw new ArgumentNullException("Id Cannot be lessthan1");
            }

            //Calling the CancelDetails method which is in BusinessLayer by passing parameter "bookingid"
            bool result= bookingHistoryManager.CancelDetails(bookingid);

            //Checking the result value
            if (result)
            {
                //If the result is true "true" will be returned With HttpActionResult "Ok"
                return Ok(true);
            }

            else
            {
               
                // If the bookingid is not present in database notfound will be thrown
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)   //using HttpResponseMessage
                {
                    Content = new StringContent(string.Format("No History found with ID = {0}", bookingid)),
                    ReasonPhrase = "BookingHistory Not Found"
                };

                throw new HttpResponseException(response);
            }
        }


        [HttpPost]
        [Route("api/BookingHistory/PostReview")]
        [ResponseType(typeof(Review))]

        public HttpResponseMessage PostReview(Review rev)
        {

            //Checking whether the object userdetail is null
            if (rev == null)
            {
                //If the userDetails is null ArgumentNullException will be thrown

                throw new ArgumentNullException("rev cannot be null");
            }

            //passing the object to DataAccesslayer by calling "SaveUserDetails" method in Businesslayer
            //which returns integer and is storing in variable  "result"

            bool result = bookingHistoryManager.SaveReviewDetails(rev);

            if (result)
            {
                //If the result is true StatusCode "201" will be returned

                return Request.CreateErrorResponse(HttpStatusCode.Created, "Account Created Sucessfully");

            }
            else
            {

                //If the result is false StatusCode "409" will be returned
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Details Already Exists");

            }


        }



        [Route("api/BookingHistory/showReview/{id}")]
        [HttpGet]
        public IHttpActionResult showReview(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentNullException("favid cant be zero");
                }
                List<ReviewOutput> result = bookingHistoryManager.showReviewBusiness(id);

                return Ok(result);

            }
            catch (ArgumentNullException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
