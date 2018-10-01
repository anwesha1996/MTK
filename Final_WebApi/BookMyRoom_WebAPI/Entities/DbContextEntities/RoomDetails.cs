using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("RoomDetails")]
    public class RoomDetails
    {
        [Key]
        public int roomId { get; set; }
        public string roomType { get; set; }
        public decimal price { get; set; }
        [ForeignKey("hotelDetails")]
        public int hotelId { get; set; }
        public HotelDetails hotelDetails { get; set; }

    }
}
