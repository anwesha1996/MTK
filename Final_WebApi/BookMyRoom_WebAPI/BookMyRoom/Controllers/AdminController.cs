using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BookMyRoom.Controllers
{
    [CustomExceptionFilter]
    public class AdminController : ApiController
    {
        private readonly AdminManager adminManager = new AdminManager();
        //Getting the number of Users , Hotels , Bookings for Dashboard
        [HttpGet]
        public int NumberOfUsers()
        {
            return adminManager.NumberOfUsers();
        }
        [Route("api/Admin/NumberOfHotels")]
        public int NumberOfHotels()
        {
            return adminManager.NumberOfHotels();
        }
        [Route("api/Admin/NumberOfBookings")]
        public int NumberOfBookings()
        {
            return adminManager.NumberOfBookings();
        }
        /*------------------------------------------------END OF DASHBOARD------------------------------------------------*/
        //CRUD Operations on Hotels Related Tab
        //Retrieving the list of cities and hotels as string from the table
        [Route("api/Admin/ListOfCities")]
        [HttpGet]
        public List<string> ListOfCities()
        {
            return adminManager.ListOfCities();
        }
        [Route("api/Admin/ListOfHotel")]
        [HttpGet]
        public List<string> ListOfHotel()
        {
            return adminManager.ListOfHotel();
        }
        /*------------------------------------------------END OF Getting List of Cities and Hotels------------------------------------------------*/
        //Deleting the city as per the choice of the admin
        [Route("api/Admin/DeleteCity")]
        public HttpResponseMessage DeleteCity(int id)
        {
            if (id < 1)
            {
                throw new ArgumentNullException("City Id cannot be null");
            }
            try
            {
                bool result = adminManager.DeleteCity(id);
                if (result)
                    return Request.CreateErrorResponse(HttpStatusCode.Accepted, "City Deleted Successfully");
                else
                    throw new ArgumentNullException("Error in deleting a City");
            }
            catch
            {

                throw new DivideByZeroException("Internal Server Error!");
            }
        }
        /*------------------------------------------------END OF Deleting the City------------------------------------------------*/
        //Adding a hotel as per the choice of the admin and mapping both the Hotel & City id to HotelCityMapping table
        [Route("api/Admin/AddHotel")]
        public HttpResponseMessage AddHotel(CityHotelDetailsFromAdmin hotel)
        {
            if (hotel.hotelName == null|| hotel.cityName==null||hotel.hotelAddress==null||hotel.hotelRating==0||(hotel.numberOfDoubleRooms==0&&hotel.numberOfSingleRooms==0)||(hotel.priceOfDoubleRoom==0&&hotel.priceOfSingleRoom==0))
            {
                throw new ArgumentNullException("Hotel Details cannot be Null");
            }
            try
            {
                bool result = adminManager.AddHotel(hotel);

                if (result)
                    return Request.CreateErrorResponse(HttpStatusCode.Created, "Hotel Added Successfully");
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Hotel Cannot be added");
            }
            catch
            {
                throw new DivideByZeroException("Internal Server Error!");
            }
        }
        /*------------------------------------------------END OF Adding Hotels------------------------------------------------*/
        //Retrieving the list of hotels from the table
        [Route("api/Admin/ListOfHotelsForAdmin")]
        [HttpGet]
        public List<HotelDetailsForAdmin> ListOfHotelsForAdmin()
        {
            return adminManager.ListOfHotels();
        }
        /*------------------------------------------------END OF Getting List of Cities------------------------------------------------*/
        //Deleting the city as per the choice of the admin
        [Route("api/Admin/DeleteHotel/{id}")]
        public HttpResponseMessage DeleteHotel(int id)
        {
            if (id < 1)
            {
                throw new ArgumentNullException("Hotel Id cannot be null");
            }
            try
            {
                bool result = adminManager.DeleteHotel(id);
                if (result)
                    return Request.CreateErrorResponse(HttpStatusCode.Accepted, "Hotel Deleted Successfully");
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No Hotels Found");
            }
            catch
            {
                throw new DivideByZeroException("Internal Server Error!");
            }
        }
        /*------------------------------------------------END OF Deleting the City------------------------------------------------*/
        //Retrieving the list of hotels from the table
        [Route("api/Admin/ListOfRooms")]
        [HttpGet]
        public List<RoomDetails> ListOfRooms(int id)
        {
            return adminManager.ListOfRooms(id);
        }
        /*------------------------------------------------END OF Getting List of Cities------------------------------------------------*/
        //Deleting the city as per the choice of the admin
        [Route("api/Admin/DeleteRoom")]
        public HttpResponseMessage DeleteRoom(int id)
        {
            if (id < 1)
                throw new ArgumentNullException("Room Id cannot be null");
            bool result = adminManager.DeleteRoom(id);
            if (result)
                return Request.CreateErrorResponse(HttpStatusCode.Accepted, "Room Deleted Successfully");
            else if (!result)
                throw new ArgumentNullException("Error in deleting a Room");
            else
                throw new DivideByZeroException("Internal Server Error!");
        }
        /*------------------------------------------------END OF Deleting the Room------------------------------------------------*/
        //CRUD Operations on User Tab
        //Retreiving the list of users in the website
        [Route("api/Admin/ListOfUsers")]
        [HttpGet]
        public List<UserDetailsForAdmin> ListOfUsers()
        {
            return adminManager.ListOfUsers();
        }
        /*------------------------------------------------END OF Getting List of Users------------------------------------------------*/
        //Editing Reward Points of a User
        [Route("api/Admin/EditUser")]
        [HttpPut]
        public HttpResponseMessage EditUser(UserDetailsForAdmin userDetails)
        {
            bool result = adminManager.EditUser(userDetails);
            if(result)
                return Request.CreateErrorResponse(HttpStatusCode.Accepted, "User Details Editted Successfully");
            else
                throw new ArgumentNullException("Error in deleting a User");
        }
        /*------------------------------------------------END OF Getting List of Users------------------------------------------------*/
        //Deleting the users as per the choice of the admin
        [Route("api/Admin/DeleteUser/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            if (id < 1)
                throw new ArgumentNullException("User Id cannot be null");
            try
            {
                bool result = adminManager.DeleteUser(id);
                if (result)
                    return Request.CreateErrorResponse(HttpStatusCode.Accepted, "User Deleted Successfully");
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User Details Not Found");
            }
            catch { 
           
                throw new DivideByZeroException("Internal Server Error!");
            }
        }
        /*------------------------------------------------END OF Deleting the User------------------------------------------------*/
        //CRUD Operations on Bookings Tab
        //Retreiving the list of bookings in the website
        [Route("api/Admin/ListOfBookings")]
        [HttpGet]
        public List<OutputForBooking> ListOfBookings()
        {
            return adminManager.ListOfBookings();
        }
        /*------------------------------------------------END OF Getting List of bookings------------------------------------------------*/
        //Deleting the bookings as per the choice of the admin
        [Route("api/Admin/DeleteBooking/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteBooking(int id)
        {
            if (id < 1)
                throw new ArgumentNullException("Booking Id cannot be null");
            bool result = adminManager.DeleteBooking(id);
            try
            {
                if (result)
                    return Request.CreateErrorResponse(HttpStatusCode.Accepted, "Booking Deleted Successfully");
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Booking Not Found");
            }
            catch
            {

                throw new DivideByZeroException("Internal Server Error!");
            }
        }
        /*------------------------------------------------END OF Deleting the User------------------------------------------------*/
        //
    }
}
