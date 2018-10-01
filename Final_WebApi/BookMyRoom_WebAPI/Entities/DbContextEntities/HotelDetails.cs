using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("HotelDetails")]
    public class HotelDetails
    {
        [Key]
        public int hotelId { get; set; }
        public string hotelName { get; set; }
        public string hotelAddress { get; set; }
        public int starRating { get; set; }
        public int singleRooms { get; set; }
        public int doubleRooms { get; set; }
    }
}
