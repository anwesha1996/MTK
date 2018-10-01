using DatabaseAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BookingHistoryManager
    {
        /// <summary>
        /// bookingchanges is the object of BookingHistoryDetails
        /// </summary>
        private readonly BookingHistoryDetails bookingchanges = new BookingHistoryDetails();

        /// <summary>
        /// GetDetails will call the Booking Method which is in DataAcessLAyer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List</returns>
        public List<History> GetDetails(int id)
        {
            //Calling Booking method which is in DataAccessLayer by passing parameter "id"

            return bookingchanges.Booking(id);
        }
        /// <summary>
        ///CancelDetaisl will call the RemoveDetails method which is in DataAccessLayer
        /// </summary>
        /// <param name="bookingid"></param>
        /// <returns></returns>
        public bool CancelDetails(int bookingid)
        {
            //Calling RemoveDetails method which is in DataAccessLayer by passing parameter "bookingid"

            return bookingchanges.RemoveDetails(bookingid);
        }
        public bool SaveReviewDetails(Review rev)
        {


            //Calling SaveUserDetails method which is in DataAccessLayer

            bool result = bookingchanges.SaveReview(rev);
            return result;
        }
        public List<ReviewOutput> showReviewBusiness(int id)
        {
            return bookingchanges.showReviewAccess(id);
        }

    }
}
