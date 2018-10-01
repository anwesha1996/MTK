using DatabaseAccessLayer;
using Entities;
using Entities.MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BookMyRoomManager
    {
        /// <summary>
        /// getroomdetails is the object for the RoomDetailsSearch Class in DataAccessLayer
        /// </summary>
        /// 
        private readonly RoomDetailsSearch getroomdetails = new RoomDetailsSearch();

        /// <summary>
        /// Method calls GetRoomDetails Method in DataAccessLayer by passing parameter gethotel
        /// </summary>
        /// <param name="gethotel"></param>
        /// <returns>List</returns>
        public List<Output> GetHotelDetails(SearchCriteria gethotel)
        { 
            //converting hotelFromDate to DateTime Type and assigning to parameter checkin

            var checkin = Convert.ToDateTime(gethotel.hotelFromDate);

            //converting hotelToDate to DateTime Type and assigning to parameter checkout

            var checkout = Convert.ToDateTime(gethotel.hotelToDate);
           
            //roomDetails is the object of list which is of type Output Class

            List<Output> roomDetails = new List<Output>();

            //today parameter stores today's date in DateTime Type

            DateTime today = DateTime.Today;

            //maxDays is the parameter which holds date which is 14 days more than today's date

            DateTime maxDays = checkin.AddDays(14);

            //maxCheckIn is the parameter which holds the date as the 90 days from today's date

            DateTime maxCheckIn = today.AddDays(90);

            //checkin date is greater than today's date and checkout date is greater than checkin and checkout should be done 14 days from checkin
           //user can give checkin date as the checkin date should not be more than 90 days from today

            if (checkin >= today && (checkout > checkin && checkout < maxDays) && (checkin < maxCheckIn))
            {
                //calling GetRoomDetails method in DataAccessLayer by passing parameter gethotel

                roomDetails = getroomdetails.GetHotelDetails(gethotel);
            }
            // returns List

            return roomDetails;
        }

        public bool Confirm_Booking(BookingTransfer savebooking)
        {
            //Calling Confirm_Booking method in DataAccessLayer

            return getroomdetails.Confirm_Booking(savebooking);
        }
        public bool RoomBookingMapping(BookingTransfer savebooking)
        {
            //Calling Confirm_Booking method in DataAccessLayer

            return getroomdetails.RoomIdBookingIdUpdate(savebooking);
        }
        public bool AddToFavListBusinessLayer(FavouriteDetails fav)
        {

            return getroomdetails.AddToFavListAccessLayer(fav);

            

        }
        public List<FavOutput> showFavBusinessLayer(int id)
        {
            return getroomdetails.showFavAccessLayer(id);
        }
        public bool DeletfavBisinessLayer(int id)
        {
            return getroomdetails.DeletfavAccessLayer(id);
            
        }


    }
}
