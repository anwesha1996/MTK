using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities.MVC.Models;
using BusinessLayer;
using Entities;

namespace BookMyRoom.Controllers
{
    [CustomExceptionFilter]
    public class BookMyRoomController : ApiController
    {
        
        /// <summary>
        /// bookMyRoomManager is the object of the class BookMyRoomManager in Business Layer
        /// </summary>
        private readonly BookMyRoomManager bookMyRoomManager = new BookMyRoomManager();

        /// <summary>
        /// Method which calls GetDetails in BusinessLayer by passing searchhotel parameter
        /// </summary>
        /// <param name="searchhotel"></param>
        /// <returns>List of Hotels</returns>
        /// 
        [HttpPut]
       
        public HttpResponseMessage SearchHotels(SearchCriteria searchhotel)
        {
            //Checking whether the object searchhotel is null
            if (searchhotel == null)
            {
                //if the searchhotel is null ArgumentNullException will be thrown
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Search Fields Values Cannot be Null");
            }

                //Calling GetHotelDetails method in Business Layer by passing searchhotel parameter which returns list

                List< Output > output= bookMyRoomManager.GetHotelDetails(searchhotel);

            //Checking whether the output is null
            if (output.Count>-1)
            {

               return new HttpResponseMessage { Content = new ObjectContent(typeof(List<Output>), output, GlobalConfiguration.Configuration.Formatters.JsonFormatter) };

            }
            else
            {
                
                // If the output is negative It will be InternalServerError
                    throw new DivideByZeroException("InternalServerError");
              
            }
           
            
        }
        [HttpPost]
        public HttpResponseMessage Confirm_Booking(BookingTransfer bookingdetails)
        {
            //Calling Confirm_Booking method in Business Layer by passing bookingdetails parameter which returns an integer
            if (bookingdetails == null)
            {
                //If the bookingdetails is null ArgumentNullException will be thrown
                throw new ArgumentNullException("Bookingdetails cannot be null");
            }
            bool result= bookMyRoomManager.Confirm_Booking(bookingdetails);

            //Checking whether the result is true or false
            if (result)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Created, "Booking is done Sucessfully");
            }
            else
            {
                //If the result is false the InternalServerError will be thrown

                throw new DivideByZeroException("InternalServerError");
            }
        }
        [Route("api/BookMyRoom/RoomBokingMapping")]
        public HttpResponseMessage RoomBookingMapping(BookingTransfer bookingdetails)
        {
            //Calling Confirm_Booking method in Business Layer by passing bookingdetails parameter which returns an integer
            if (bookingdetails == null)
            {
                //If the bookingdetails is null ArgumentNullException will be thrown
                throw new ArgumentNullException("Bookingdetails cannot be null");
            }
            bool result = bookMyRoomManager.RoomBookingMapping(bookingdetails);

            //Checking whether the result is true or false
            if (result)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Room Mapping is done  Sucessfully");
            }
            else
            {
                //If the result is false the InternalServerError will be thrown

                throw new DivideByZeroException("InternalServerError");
            }
        }
        [Route("api/BookMyRoom/AddFavlist")]
        [HttpPost]
        public IHttpActionResult AddFavlist(FavouriteDetails fav)
        {

            //bool res = bookMyRoomManager.AddToFavListBusinessLayer(fav);
            //return Ok();
            try
            {
                if (fav == null)
                {
                    throw new ArgumentNullException("Favouritedetails cant be null");
                }
                bool result = bookMyRoomManager.AddToFavListBusinessLayer(fav);

                return Ok();

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
        [Route("api/BookMyRoom/showFav/{id}")]
        [HttpGet]
        public IHttpActionResult showFav(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentNullException("favid cant be zero");
                }
                List<FavOutput> result = bookMyRoomManager.showFavBusinessLayer(id);

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
        [Route("api/BookMyRoom/DeletFav/{id}")]
        [HttpDelete]
        public IHttpActionResult DeletFav(int id)
        {
           
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("deleteid  cant be null");
                }
                bool final = bookMyRoomManager.DeletfavBisinessLayer(id);
                return Ok(final);
            }
            catch (ArgumentException argex)
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
