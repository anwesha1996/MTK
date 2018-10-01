using DatabaseAccessLayer.DbContext;
using Entities;
using Entities.MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
   
    public class RoomDetailsSearch
    {
        /// <summary>
        /// dbContext is the object of BookMyRoomDBContext
        /// </summary>
        /// 
        private readonly BookMyRoomDBContext dbContext = new BookMyRoomDBContext();

        /// <summary>
        /// Getting the Hoteldetails based on search criteria
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>List</returns>
        public List<Output> GetHotelDetails(SearchCriteria hotel)
        {
            //Grouping Rooms based on booking that are coming in the range of checkin and checkout dates,city and roomtype entered by the user
            try
            {
                var notAvailable = (from booking in dbContext.booking
                                    join roomBookingDetails in dbContext.roomBookingDetails on booking.bookingId equals roomBookingDetails.bookingId
                                    join roomDetails in dbContext.roomHotel on roomBookingDetails.roomId equals roomDetails.roomId
                                    join hotelDetails in dbContext.hotelDetails on roomDetails.hotelId equals hotelDetails.hotelId
                                    join hotelCityMap in dbContext.hotelCityMap on hotelDetails.hotelId equals hotelCityMap.hotelId
                                    join cityDetails in dbContext.cityDetails on hotelCityMap.cityId equals cityDetails.cityId
                                    where cityDetails.cityName == hotel.hotelCity && roomDetails.roomType == hotel.hotelRoomType
                                    group booking by roomDetails.roomId into roomAllot
                                    select new
                                    {
                                        bookingId = (from item in roomAllot
                                                     where !((item.checkInDate >= hotel.hotelFromDate && item.checkInDate >= hotel.hotelToDate) || (item.checkOutDate <= hotel.hotelFromDate && item.checkOutDate <= hotel.hotelFromDate))
                                                     select item.bookingId)
                                    }).ToList();
                //Ungrouping the bookingId from the sublist of rooms
                List<int> bookingIdList = new List<int>();
                int first;
                foreach (var item in notAvailable)
                {
                    first = 0;
                    foreach (var bookingId in item.bookingId)
                    {
                        bookingIdList.Add(bookingId);
                        if (first == 0)
                            break;
                    }
                }
                //Getting the details of the rooms that are not available within the range of checkIn and checkout dates entered by the user
                List<Output> notAvailableHotels = new List<Output>();
                foreach (int id in bookingIdList)
                {
                    var detailsOfRoomsById = (from booking in dbContext.booking
                                              join roomBookingDetails in dbContext.roomBookingDetails on booking.bookingId equals roomBookingDetails.bookingId
                                              join roomDetails in dbContext.roomHotel on roomBookingDetails.roomId equals roomDetails.roomId
                                              join hotelDetails in dbContext.hotelDetails on roomDetails.hotelId equals hotelDetails.hotelId
                                              join hotelCityMap in dbContext.hotelCityMap on hotelDetails.hotelId equals hotelCityMap.hotelId
                                              join cityDetails in dbContext.cityDetails on hotelCityMap.cityId equals cityDetails.cityId
                                              where (booking.bookingId == id)
                                              select new Output
                                              {
                                                  hotelId = hotelDetails.hotelId,
                                                  roomId = roomDetails.roomId,
                                                  hotelName = hotelDetails.hotelName,
                                                  hotelRoomType = roomDetails.roomType,
                                                  hotelFromDate = hotel.hotelFromDate,
                                                  hotelToDate = hotel.hotelToDate,
                                                  hotelPrice = roomDetails.price,
                                                  hotelCity = cityDetails.cityName,
                                                  hotelRating = hotelDetails.starRating,
                                                  hotelAddress = hotelDetails.hotelAddress


                                              }).Distinct().ToList();
                    foreach (Output items in detailsOfRoomsById.Cast<object>().ToArray())
                    {

                        notAvailableHotels.Add(items);


                    }

                }
                //Getting a list of available booked hotels based on the checking of bookingId
                var excludedAvailableBookedHotels = (from booking in dbContext.booking
                                                     join roomBookingDetails in dbContext.roomBookingDetails on booking.bookingId equals roomBookingDetails.bookingId
                                                     join roomDetails in dbContext.roomHotel on roomBookingDetails.roomId equals roomDetails.roomId
                                                     join hotelDetails in dbContext.hotelDetails on roomDetails.hotelId equals hotelDetails.hotelId
                                                     join hotelCityMap in dbContext.hotelCityMap on hotelDetails.hotelId equals hotelCityMap.hotelId
                                                     join cityDetails in dbContext.cityDetails on hotelCityMap.cityId equals cityDetails.cityId
                                                     where (roomDetails.roomType == hotel.hotelRoomType && cityDetails.cityName == hotel.hotelCity)
                                                     select new Output
                                                     {
                                                         hotelId = hotelDetails.hotelId,
                                                         roomId = roomDetails.roomId,
                                                         hotelName = hotelDetails.hotelName,
                                                         hotelRoomType = roomDetails.roomType,
                                                         hotelFromDate = hotel.hotelFromDate,
                                                         hotelToDate = hotel.hotelToDate,
                                                         hotelPrice = roomDetails.price,
                                                         hotelCity = cityDetails.cityName,
                                                         hotelRating = hotelDetails.starRating,
                                                         hotelAddress = hotelDetails.hotelAddress

                                                     }).Distinct().ToList();
                excludedAvailableBookedHotels.RemoveAll(x => notAvailableHotels.Any(y => y.roomId == x.roomId));

                //Getting a list of all the booked hotels based on the city and roomtype preferred by the user

                var totalBookedHotels = (from booking in dbContext.booking
                                         join roomBookingDetails in dbContext.roomBookingDetails on booking.bookingId equals roomBookingDetails.bookingId
                                         join roomDetails in dbContext.roomHotel on roomBookingDetails.roomId equals roomDetails.roomId
                                         join hotelDetails in dbContext.hotelDetails on roomDetails.hotelId equals hotelDetails.hotelId
                                         join hotelCityMap in dbContext.hotelCityMap on hotelDetails.hotelId equals hotelCityMap.hotelId
                                         join cityDetails in dbContext.cityDetails on hotelCityMap.cityId equals cityDetails.cityId
                                         where (roomDetails.roomType == hotel.hotelRoomType && cityDetails.cityName == hotel.hotelCity)
                                         select new Output
                                         {
                                             hotelId = hotelDetails.hotelId,
                                             roomId = roomDetails.roomId,
                                             hotelName = hotelDetails.hotelName,
                                             hotelRoomType = roomDetails.roomType,
                                             hotelFromDate = hotel.hotelFromDate,
                                             hotelToDate = hotel.hotelToDate,
                                             hotelPrice = roomDetails.price,
                                             hotelCity = cityDetails.cityName,
                                             hotelRating = hotelDetails.starRating,
                                             hotelAddress = hotelDetails.hotelAddress

                                         }).Distinct().ToList();

                //Getting a list of all the hotels that come under the city and roomtype specified by the user

                var totalHotels = (from hotelDetails in dbContext.hotelDetails
                                   join hotelCityMap in dbContext.hotelCityMap on hotelDetails.hotelId equals hotelCityMap.hotelId
                                   join cityDetails in dbContext.cityDetails on hotelCityMap.cityId equals cityDetails.cityId
                                   join roomDetails in dbContext.roomHotel on hotelDetails.hotelId equals roomDetails.hotelId
                                   where
                                   cityDetails.cityName == hotel.hotelCity
                                   && roomDetails.roomType == hotel.hotelRoomType
                                   select new Output
                                   {
                                       hotelId = hotelDetails.hotelId,
                                       roomId = roomDetails.roomId,
                                       hotelName = hotelDetails.hotelName,
                                       hotelRoomType = roomDetails.roomType,
                                       hotelFromDate = hotel.hotelFromDate,
                                       hotelToDate = hotel.hotelToDate,
                                       hotelPrice = roomDetails.price,
                                       hotelCity = cityDetails.cityName,
                                       hotelRating = hotelDetails.starRating,
                                       hotelAddress = hotelDetails.hotelAddress

                                   }).Distinct().ToList();

                //Removing the list of totalBookedHotels from the totalHotels list

                totalHotels.RemoveAll(x => totalBookedHotels.Any(y => y.roomId == x.roomId));

                //Concatenating the totalHotels list with the availableBookedHotels list to get the output desired by the user

                var result = totalHotels.Concat(excludedAvailableBookedHotels).ToList<Output>();

                List<int> hotelIdArray = new List<int>();
                foreach (var returnedHotels in result)
                {
                    hotelIdArray.Add(returnedHotels.hotelId);
                }
                List<int> distinctHotelIds = hotelIdArray.Distinct().ToList();
                Random rand = new Random();
                List<Output> semiResult = new List<Output>();
                List<Output> finalResult = new List<Output>();
                foreach (var id in distinctHotelIds)
                {
                    foreach (var hotels in result)
                    {
                        if (id == hotels.hotelId)
                        {
                            semiResult.Add(hotels);
                        }
                    }
                    int no = rand.Next(semiResult.Count);
                    finalResult.Add(semiResult[no]);
                    semiResult.Clear();
                }
                return finalResult;
            }
            catch (Exception ex)
            {
                throw new DivideByZeroException("Internal Server Error");
            }
        }


        /// <summary>
        /// Booking details are added to Database
        /// </summary>
        /// <param name="confirmbooking"></param>
        /// <returns>int</returns>
        public bool Confirm_Booking(BookingTransfer confirmbooking)

        {
            //book is the object for Booking class
            //assigning the values of Booking Transfer to Confirmbooking

            ConfirmBooking book = new ConfirmBooking();
            book.bookingAmount = confirmbooking.bookingAmount;
            book.checkInDate = confirmbooking.checkInDate;
            book.checkOutDate = confirmbooking.checkOutDate;
            book.discountAmount = confirmbooking.discountAmount;
            book.bookingDate = DateTime.Today;

            confirmbooking.bookingDate = book.bookingDate;

            List<int> findbooking = dbContext.roomBookingDetails.Where(x => x.roomId == confirmbooking.roomId).Select(y => y.bookingId).ToList();
            foreach (var bookId in findbooking)
            {
                ConfirmBooking findbook = dbContext.booking.Find(bookId);
                if (!((findbook.checkInDate >= confirmbooking.checkInDate && findbook.checkInDate >= confirmbooking.checkOutDate) || (findbook.checkOutDate <= confirmbooking.checkInDate && findbook.checkOutDate <= confirmbooking.checkOutDate)))
                {
                    return false;
                }

            }

            //updating the database with object 
            try
            {
                // Adding new row to Booking table with Add method

                dbContext.booking.Add(book);

                //After adding saving changes with SaveChanges method

                dbContext.SaveChanges();



            }

            //catch block will be called when any error occurs while saving in database

            catch
            {
                return false;


            }
            return true;
        }

        /// <summary>
        /// For Mapping table so that the booked rooms will not be shown
        /// </summary>
        /// <param name="obj"></param>
        public bool RoomIdBookingIdUpdate (BookingTransfer obj)
        {
            
            obj.bookingDate = DateTime.Today;
            List<int> bookingIds = (from booking in dbContext.booking
                                    where booking.bookingDate == obj.bookingDate && booking.checkInDate == obj.checkInDate
                                    && booking.checkOutDate == obj.checkOutDate && booking.bookingAmount == obj.bookingAmount
                                    && booking.discountAmount == obj.discountAmount
                                    select booking.bookingId).ToList();
            List<int> allBookingIds = (from map in dbContext.roomBookingDetails
                                       select map.bookingId).ToList();
            List<int> idsToBeExcluded = new List<int>();
            foreach(int id in bookingIds)
            {
                foreach (int ids in allBookingIds)
                {
                    if (id == ids)
                    {
                        idsToBeExcluded.Add(id);
                    }
                }
            }
            if (idsToBeExcluded.Count != 0)
            {
                bookingIds.RemoveAll(x => idsToBeExcluded.Any(y => y == x));
            }
            try
            {
                
               
                int bookingIdToMap = bookingIds[0];
                RoomBookingDetails roomBookingUpdate = new RoomBookingDetails();

                roomBookingUpdate.bookingId = bookingIdToMap;
                roomBookingUpdate.roomId = obj.roomId;
                roomBookingUpdate.userId = obj.userId;
                //Adding the roomBookingUpdate object to database
                dbContext.roomBookingDetails.Add(roomBookingUpdate);
                dbContext.SaveChanges();
                
            }
            catch(Exception ex)
            {
                return false;
                
            }
            return true;
        }
        public bool AddToFavListAccessLayer(FavouriteDetails fav)
        {
            var details = (dbContext.favouriteDetails.
                           Where(x => x.userId == fav.userId && x.hotelId == fav.hotelId)).ToList();


            if (details.Count == 0)
            {
                dbContext.favouriteDetails.Add(fav);
                dbContext.SaveChanges();
                return true;
            }

            else
            {

                return false;
            }
        }
        public List<FavOutput> showFavAccessLayer(int id)
        {
            var favhotel = (from hotelDetails in dbContext.hotelDetails
                            join hotelCityMap in dbContext.hotelCityMap on hotelDetails.hotelId equals hotelCityMap.hotelId
                            join cityDetails in dbContext.cityDetails on hotelCityMap.cityId equals cityDetails.cityId
                            join roomDetails in dbContext.roomHotel on hotelDetails.hotelId equals roomDetails.hotelId
                            join Fav in dbContext.favouriteDetails on hotelDetails.hotelId equals Fav.hotelId

                            where (Fav.userId == id)
                            select new FavOutput
                            {
                                hotelName = hotelDetails.hotelName,
                                hotelAddress = hotelDetails.hotelAddress,
                                starRating = hotelDetails.starRating,
                                price = roomDetails.price,
                                hotelId = hotelDetails.hotelId,
                                favId = Fav.favId,
                                roomId = roomDetails.roomId,

                            }).ToList<FavOutput>();
            List<int> hotelIdArray = new List<int>();
            foreach (var returnedHotels in favhotel)
            {
                hotelIdArray.Add(returnedHotels.hotelId);
            }
            List<int> distinctHotelIds = hotelIdArray.Distinct().ToList();
            Random rand = new Random();
            List<FavOutput> semiResult = new List<FavOutput>();
            List<FavOutput> finalResult = new List<FavOutput>();
            foreach (var ID in distinctHotelIds)
            {
                foreach (var hotels in favhotel)
                {
                    if (ID == hotels.hotelId)
                    {
                        semiResult.Add(hotels);
                    }
                }
                int no = rand.Next(semiResult.Count);
                finalResult.Add(semiResult[no]);
                semiResult.Clear();
            }
            return finalResult;

        }
        public bool DeletfavAccessLayer(int id)
        {
            FavouriteDetails fav = dbContext.favouriteDetails.Find(id);

            if (fav != null)
            {
                dbContext.favouriteDetails.Remove(fav);
                dbContext.SaveChanges();
                return true;
            }
            else
                return false;


        }
        }
    }
