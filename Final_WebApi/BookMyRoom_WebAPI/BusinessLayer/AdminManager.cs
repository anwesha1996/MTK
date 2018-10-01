using DatabaseAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer
{
    public class AdminManager
    {
        private readonly AdminUpgrades adminUpgrades = new AdminUpgrades();
        //Returning the integer value to AdminController received from DataAccessLayer
        public int NumberOfUsers()
        {
            int noOfUsers = adminUpgrades.NumberOfUsers();
            return noOfUsers;
        }
        //Returning the integer value to AdminController received from DataAccessLayer
        public int NumberOfHotels()
        {
            int noOfHotels = adminUpgrades.NumberOfHotels();
            return noOfHotels;
        }
        //Returning the integer value to AdminController received from DataAccessLayer
        public int NumberOfBookings()
        {
            int noOfBookings = adminUpgrades.NumberOfBookings();
            return noOfBookings;
        }
        /*------------------------------------------------END OF DASHBOARD------------------------------------------------*/
        //Returning the list of cities and hotels as string to AdminController received from DataAccessLayer
        public List<string> ListOfCities()
        {
            return adminUpgrades.ListOfCities();
        }
        public List<string> ListOfHotel()
        {
            return adminUpgrades.ListOfHotel();
        }
        /*------------------------------------------------END OF Getting List of Cities and Hotels------------------------------------------------*/
        //Returning a boolean value to AdminController received from DataAccessLayer based on successful deletion of city
        public bool DeleteCity(int id)
        {
            bool result = adminUpgrades.DeleteCity(id);
            if (result)
                return true;
            else
                return false;
        }
        /*------------------------------------------------END OF Deleting the City------------------------------------------------*/

        //Returning a boolean value to AdminController received from DataAccessLayer based on successful addition of a Hotel
        public bool AddHotel(CityHotelDetailsFromAdmin hotel)
        {
            bool result = adminUpgrades.AddHotel(hotel);
            if (result)
                return true;
            else
                return false;
        }
        /*------------------------------------------------END OF Adding Hotel------------------------------------------------*/
        //Returning the list of hotels to AdminController received from DataAccessLayer
        public List<HotelDetailsForAdmin> ListOfHotels()
        {
            return adminUpgrades.ListOfHotels();
        }
        /*------------------------------------------------END OF Getting List of Hotels------------------------------------------------*/
        //Returning a boolean value to AdminController received from DataAccessLayer based on successful deletion of hotel
        public bool DeleteHotel(int id)
        {
            bool result = adminUpgrades.DeleteHotel(id);
            if (result)
                return true;
            else
                return false;
        }
        /*------------------------------------------------END OF Deleting the Hotel------------------------------------------------*/
        ////Returning the list of rooms to AdminController received from DataAccessLayer based on hotelId
        public List<RoomDetails> ListOfRooms(int id)
        {
            return adminUpgrades.ListOfRooms(id);
        }
        /*------------------------------------------------END OF Getting List of Cities------------------------------------------------*/
        //Returning a boolean value to AdminController received from DataAccessLayer based on successful deletion of room
        public bool DeleteRoom(int id)
        {
            bool result = adminUpgrades.DeleteRoom(id);
            if (result)
                return true;
            else
                return false;
        }
        /*------------------------------------------------END OF Deleting the Room------------------------------------------------*/
        

        //Returning the list of Users to AdminController received from DataAccessLayer
        public List<UserDetailsForAdmin> ListOfUsers()
        {
            return adminUpgrades.ListOfUsers();
        }
        /*------------------------------------------------END OF Getting List of Users------------------------------------------------*/
        //Returning a boolean value to AdminController received from DataAccessLayer based on successful edit of user reward points
        public bool EditUser(UserDetailsForAdmin userDetails)
        {
            bool result = adminUpgrades.EditUser(userDetails);
            if (result)
                return true;
            else
                return false;
        }
        /*------------------------------------------------END OF Editing Reward Points of the User------------------------------------------------*/
        //Returning a boolean value to AdminController received from DataAccessLayer based on successful deletion of user
        public bool DeleteUser(int id)
        {
            bool result = adminUpgrades.DeleteUser(id);
            if (result)
                return true;
            else
                return false;
        }
        /*------------------------------------------------END OF Deleting the User------------------------------------------------*/
        //Returning the list of Users to AdminController received from DataAccessLayer
        public List<OutputForBooking> ListOfBookings()
        {
            return adminUpgrades.ListOfBookings();
        }
        /*------------------------------------------------END OF Getting List of Users------------------------------------------------*/
        //Returning a boolean value to AdminController received from DataAccessLayer based on successful deletion of user
        public bool DeleteBooking(int id)
        {
            bool result = adminUpgrades.DeleteBooking(id);
            if (result)
                return true;
            else
                return false;
        }
        /*------------------------------------------------END OF Deleting the Booking------------------------------------------------*/
    }
}
