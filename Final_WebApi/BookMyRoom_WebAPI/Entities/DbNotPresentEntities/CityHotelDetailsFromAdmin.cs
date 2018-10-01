using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CityHotelDetailsFromAdmin
    {
        public string cityName { get; set; }
        public string hotelName { get; set; }
        public int hotelRating { get; set; }
        public string hotelAddress { get; set; }
        public int numberOfSingleRooms { get; set; }
        public decimal priceOfSingleRoom { get; set; }
        public int numberOfDoubleRooms { get; set; }
        public decimal priceOfDoubleRoom { get; set; }
        public string hotelimage1 { get; set; }
        public string hotelimage2 { get; set; }
        public string hotelimage3 { get; set; }
    }
}
