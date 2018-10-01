using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OutputForBooking
    {
        public int bookingId { get; set; }
        public string name { get; set; }
        public string bookingDate { get; set; }
        public string combinedDate { get; set; }
        public decimal amount { get; set; }
        public string hotelName { get; set; }
        public string cityName { get; set; }
    }
}
