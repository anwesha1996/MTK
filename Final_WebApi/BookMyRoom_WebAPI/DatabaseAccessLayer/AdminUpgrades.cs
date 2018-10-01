using DatabaseAccessLayer.DbContext;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DatabaseAccessLayer
{
    public class AdminUpgrades
    {
        private readonly BookMyRoomDBContext dbContext = new BookMyRoomDBContext();

        //Dashboard For Admin
        //Getting the count of Users registered till now
        public int NumberOfUsers()
        {
            int noOfUsers = (from users in dbContext.userDetails
                             select users).Count();
            return noOfUsers;
        }
        //Getting the count of Hotels in the database
        public int NumberOfHotels()
        {
            int noOfHotels = (from hotels in dbContext.hotelDetails
                              select hotels).Count();
            return noOfHotels;
        }
        //Getting the count of Hotels in the database
        public int NumberOfBookings()
        {
            int noOfBookings = (from bookings in dbContext.booking
                                select bookings).Count();
            return noOfBookings;
        }
        /*------------------------------------------------END OF DASHBOARD------------------------------------------------*/
        // CRUD on City Table
        //Adding City in the cityDetails Table
        public bool AddCity(CityDetails city)
        {
            dbContext.cityDetails.Add(city);
            dbContext.SaveChanges();
            return true;
        }
        //Checking if the city exists or not
        public bool CheckCityIfExists(string cityName)
        {
            int check = dbContext.cityDetails.Count(x => x.cityName == cityName);
            if (check < 1)
                return true;
            else
                return false;
        }
        /*------------------------------------------------END OF Adding City------------------------------------------------*/
        //Getting list of cities and hotels as string from cityDetails and hotelDetails Table
        public List<string> ListOfCities()
        {
            //Getting the full list of Cities 
            List<string> listOfCities = dbContext.cityDetails.Select(y => y.cityName).ToList();
            return listOfCities;
        }
        public List<string> ListOfHotel()
        {
            List<string> listOfHotels = dbContext.hotelDetails.Select(y => y.hotelName).ToList();

            return listOfHotels;
        }
        /*------------------------------------------------END OF Getting List of Cities and Hotels------------------------------------------------*/
        //Deleting the city from cityDetails using the id
        public bool DeleteCity(int id)
        {
            CityDetails cityDetails = dbContext.cityDetails.Find(id);
            if (cityDetails != null)
            {
                dbContext.cityDetails.Remove(cityDetails);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        /*------------------------------------------------END OF Deleting the City------------------------------------------------*/
        // CRUD on Hotel Table
        //Adding Hotel in the hotelDetails Table
        public bool AddHotel(CityHotelDetailsFromAdmin hotel)
        {
            CityDetails cityDetails = new CityDetails();
            cityDetails.cityName = hotel.cityName;


            HotelDetails hotelDetails = new HotelDetails();
            hotelDetails.hotelName = hotel.hotelName;
            hotelDetails.hotelAddress = hotel.hotelAddress;
            hotelDetails.doubleRooms = hotel.numberOfDoubleRooms;
            hotelDetails.starRating = hotel.hotelRating;
            hotelDetails.singleRooms=hotel.numberOfSingleRooms;

            RoomDetails roomDetails = new RoomDetails();

            if (CheckCityIfExists(cityDetails.cityName))
            {
                if (!AddCity(cityDetails)) { return false; }
            }
            int cityId = dbContext.cityDetails.Where(y => y.cityName == cityDetails.cityName).Select(y => y.cityId).FirstOrDefault();
            if (CheckHotelIfExists(hotelDetails.hotelName, cityId))
            {

                dbContext.hotelDetails.Add(hotelDetails);
                dbContext.SaveChanges();
                int hotelId = FindTheAppropriateHotelId(hotel.hotelName);
                //Calling a different function to map Hotel and City Id
                if (!CityIdHotelIdUpdate(cityId, hotelId)) { return false; }

                //Starting to add rooms
                for (int i = 1; i <= hotel.numberOfSingleRooms; i++)
                {
                    roomDetails.hotelId = hotelId;
                    roomDetails.roomType = "Single";
                    roomDetails.price = hotel.priceOfSingleRoom;

                    if (!AddRoom(roomDetails)) { return false; }
                }
                for (int i = 1; i <= hotel.numberOfDoubleRooms; i++)
                {
                    roomDetails.hotelId = hotelId;
                    roomDetails.roomType = "Double";
                    roomDetails.price = hotel.priceOfDoubleRoom;

                    if (!AddRoom(roomDetails)) { return false; }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        //Finding the Appropriate Hotel Id
        public int FindTheAppropriateHotelId(string hotelName)
        {
            List<int> hotelId = dbContext.hotelDetails.Where(x => x.hotelName == hotelName).Select(y => y.hotelId).ToList();
            foreach (int id in hotelId)
            {
                HotelCityMapping details = dbContext.hotelCityMap.Find(id);
                if (details == null)
                {
                    return id;
                }
            }
            return 0;
        }
        //Checking if the hotel exists or not
        public bool CheckHotelIfExists(string hotelName, int cityId)
        {
            int check = (from hotelDetails in dbContext.hotelDetails
                         join hotelCityMap in dbContext.hotelCityMap on hotelDetails.hotelId equals hotelCityMap.hotelId
                         join cityDetails in dbContext.cityDetails on hotelCityMap.cityId equals cityDetails.cityId
                         where hotelName == hotelDetails.hotelName && cityId == cityDetails.cityId
                         select hotelDetails.hotelName).Count();
            if (check < 1)
                return true;
            else
                return false;
        }
        //Retrieving the hotelId using the details send by the admin and mapping it with cityId
        public bool CityIdHotelIdUpdate(int cityId, int hotelId)
        {
            if (cityId > 0 && hotelId > 0)
            {

                HotelCityMapping mapping = new HotelCityMapping();
                mapping.cityId = cityId;
                mapping.hotelId = hotelId;
                dbContext.hotelCityMap.Add(mapping);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        /*------------------------------------------------END OF Adding Hotel------------------------------------------------*/
        


        //Getting list of cities from cityDetails Table
        public List<HotelDetailsForAdmin> ListOfHotels()
        {
            //Getting the full list of Cities 
            var listOfCities = (from hotelDetails in dbContext.hotelDetails
                                join map in dbContext.hotelCityMap on hotelDetails.hotelId equals map.hotelId
                                join cityDetails in dbContext.cityDetails on map.cityId equals cityDetails.cityId
                               // join roomDetails in dbContext.roomHotel on hotelDetails.hotelId equals roomDetails.roomId
                                select new HotelDetailsForAdmin
                                {
                                    hotelID = hotelDetails.hotelId,
                                    hotelCity = cityDetails.cityName,
                                    hotelName = hotelDetails.hotelName,
                                    hotelRating = hotelDetails.starRating
                                }).Distinct().ToList();
            return listOfCities;
        }
        /*------------------------------------------------END OF Getting List of Cities------------------------------------------------*/
        //Deleting the city from cityDetails using the id
        public bool DeleteHotel(int id)
        {
            HotelDetails hotelDetails = dbContext.hotelDetails.Find(id);
            if (hotelDetails != null)
            {
                DeleteRoomOfAHotel(id);
                dbContext.hotelDetails.Remove(hotelDetails);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        //Deleting the rooms of that particular hotel
        public bool DeleteRoomOfAHotel(int id)
        {
            try
            {
                List<RoomDetails> allRoomsInThisHotel = dbContext.roomHotel.Where(x => x.hotelId == id).Select(y => y).ToList();
                foreach (var rooms in allRoomsInThisHotel)
                {
                    dbContext.roomHotel.Remove(rooms);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /*------------------------------------------------END OF Deleting the Hotel------------------------------------------------*/
        // CRUD on Room Table
        //Adding Room in the RoomDetails Table
        public bool AddRoom(RoomDetails room)
        {
            try
            {
                dbContext.roomHotel.Add(room);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /*------------------------------------------------END OF Adding Room------------------------------------------------*/
        //Getting list of rooms from roomDetails Table based on hotelId
        public List<RoomDetails> ListOfRooms(int id)
        {
            //var listOfHotels = (from rooms in dbContext.roomHotel
            //                    where rooms.hotelId == id
            //                    select new RoomDetails
            //                    {
            //                        roomId = rooms.roomId,
            //                        roomNumber = rooms.roomNumber,
            //                        roomType = rooms.roomType,
            //                        price = rooms.price,
            //                        starRating = rooms.starRating,
            //                        imageUrl = rooms.imageUrl,
            //                        hotelId = rooms.hotelId
            //                    }).Distinct().ToList();
            List<RoomDetails> listOfHotels = dbContext.roomHotel.Where(x => x.hotelId == id).Select(y => y).ToList();
            return listOfHotels;
        }
        /*------------------------------------------------END OF Getting List of Rooms------------------------------------------------*/
        //Deleting the rooms from roomDetails using the id
        public bool DeleteRoom(int id)
        {
            RoomDetails roomDetails = dbContext.roomHotel.Find(id);
            if (roomDetails != null)
            {
                dbContext.roomHotel.Remove(roomDetails);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        /*------------------------------------------------END OF Deleting the Room------------------------------------------------*/
        //Getting list of users from usersDetails Table
        public List<UserDetailsForAdmin> ListOfUsers()
        {
            //Getting the full list of Users 
            var listOfUsers = (from userDetails in dbContext.userDetails
                               select new UserDetailsForAdmin
                               {
                                   userID = userDetails.userId,
                                   userEmail = userDetails.email,
                                   userFullName = userDetails.name,
                                   userPhone = userDetails.mobileNo,
                                   rewardPoints = userDetails.rewardPoints
                               }).Distinct().ToList();
            return listOfUsers;
        }
        /*------------------------------------------------END OF Getting List of Users------------------------------------------------*/
        //Updating the edited reward points received from the controller
        public bool EditUser(UserDetailsForAdmin userDetails)
        {
            UserDetails fullUserDetails = dbContext.userDetails.Find(userDetails.userID);
            if (fullUserDetails != null)
            {
                fullUserDetails.rewardPoints = userDetails.rewardPoints;
                dbContext.Entry(fullUserDetails).State = EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
        /*------------------------------------------------END OF Editing Reward Points of User------------------------------------------------*/
        //Deleting the user from userDetails using the id
        public bool DeleteUser(int id)
        {
            UserDetails userDetails = dbContext.userDetails.Find(id);
            if (userDetails != null)
            {
                dbContext.userDetails.Remove(userDetails);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        /*------------------------------------------------END OF Deleting the User------------------------------------------------*/
        public List<OutputForBooking> ListOfBookings()
        {
            //Getting the full list of Users 
            var listOfBookings = (from booking in dbContext.booking
                                  join mapOfBooking in dbContext.roomBookingDetails on booking.bookingId equals mapOfBooking.bookingId
                                  join userDetails in dbContext.userDetails on mapOfBooking.userId equals userDetails.userId
                                  join roomDetails in dbContext.roomHotel on mapOfBooking.roomId equals roomDetails.roomId
                                  join hotelDetails in dbContext.hotelDetails on roomDetails.hotelId equals hotelDetails.hotelId
                                  join hotelCityMap in dbContext.hotelCityMap on hotelDetails.hotelId equals hotelCityMap.hotelId
                                  join cityDetails in dbContext.cityDetails on hotelCityMap.cityId equals cityDetails.cityId
                                  select new OutputForBooking
                                  {
                                      bookingId = booking.bookingId,
                                      amount = booking.bookingAmount,
                                      bookingDate = booking.bookingDate.ToString(),
                                      cityName = cityDetails.cityName,
                                      hotelName = hotelDetails.hotelName,
                                      name = userDetails.name,
                                      combinedDate = booking.checkInDate.ToString() + "-" + booking.checkOutDate.ToString()
                                  }).Distinct().ToList();
            return listOfBookings;
        }
        /*------------------------------------------------END OF Getting List of Bookings------------------------------------------------*/
        //Deleting the user from userDetails using the id
        public bool DeleteBooking(int id)
        {
            ConfirmBooking bookingDetails = dbContext.booking.Find(id);
            if (bookingDetails != null)
            {
                dbContext.booking.Remove(bookingDetails);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        /*------------------------------------------------END OF Deleting the Bookings------------------------------------------------*/
        //List of 
    }
}
