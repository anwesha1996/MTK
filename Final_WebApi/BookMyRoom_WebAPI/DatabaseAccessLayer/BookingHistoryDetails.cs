using DatabaseAccessLayer.DbContext;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class BookingHistoryDetails
    {
        /// <summary>
        /// db is the object for BookMyRoomDBContextClass
        /// </summary>
        private readonly BookMyRoomDBContext db = new BookMyRoomDBContext();

        /// <summary>
        /// Booking method will returns List of History based on parameter "id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List</returns>
        public List<History> Booking(int id)
        {
            //Storing the History List into parameter bookingHistory which is obtained from LINQ statement

            using (BookMyRoomDBContext db = new BookMyRoomDBContext())
            {
                var bookingHistory = (from RBD in db.roomBookingDetails
                                      join UD in db.userDetails on RBD.userId equals UD.userId
                                      join B in db.booking on RBD.bookingId equals B.bookingId
                                      join RD in db.roomHotel on RBD.roomId equals RD.roomId
                                      join HD in db.hotelDetails on RD.hotelId equals HD.hotelId
                                      where id == UD.userId
                                      select new History
                                      {
                                          hotelId = HD.hotelId,
                                          hotelName = HD.hotelName,
                                          hotelCity = "",
                                          hotelAddress = HD.hotelAddress,
                                          bookingDate = B.bookingDate,
                                          bookingId = B.bookingId,
                                          checkInDate = B.checkInDate,
                                          checkOutDate = B.checkOutDate
                                      }).ToList();

                return bookingHistory;
            }
        }

        /// <summary>
        /// RemoveDetails will remove particular record based on the parameter "id"
        /// </summary>
        /// <param name="bookingid"></param>
        /// <returns>bool</returns>
        public bool RemoveDetails(int bookingid)
        {
            
            try
            {
                //Based on parameter "id" by using .Find method we find entire row
                ConfirmBooking book = db.booking.Find(bookingid);
                //.Remove method removes the row of the object
                db.booking.Remove(book);
                //Saving changes to database
                db.SaveChanges();
            }
            //Catch block will hit when there is error while save in database
            catch
            {
                //false will be returned due to error
                return false;
            }
            //If the savechanges method works then true will be returned
            return true ;
        }

        public bool SaveReview(Review rev)
        {
            //RewardPoints is the property of UserDetails Class. Whenever A person Signup, he will get 5 points as rewards

            //try block will try to add the userdetails in Database.

            try
            {
                //Using BookMyRoomDBContext class object we are accessing the Userdetails table by using UserDetails table object userDetails
                //Add method is used to new data into table by passing an object

                db.reviews.Add(rev);

                //SaveChanges method is to save changes after adding object to table in Database

                db.SaveChanges();
            }

            //Catch block will hits when the SaveChanges Method fails
            //When we try to save already existed UserName, Email it will hits

            catch
            {
                //Catch block returns 0 when the details are not saved

                return false;
            }

            //If the details are added into DataBase successfully returns 1

            return true;
        }

        public List<ReviewOutput> showReviewAccess(int id)
        {
            var Output = (from rev in db.reviews
                          where (rev.hotelId == id)
                          select new ReviewOutput
                          {
                              rating = rev.rating,
                              review = rev.review,
                              hotelId = rev.hotelId
                          }).ToList<ReviewOutput>();
            return Output;
        }
    }
}
