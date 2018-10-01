using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("RoomBookingDetails")]
    public class RoomBookingDetails
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("roomDetails")]
        public int roomId { get; set; }
        public RoomDetails roomDetails { get; set; }
        [ForeignKey("book")]
        public int bookingId { get; set; }
        public ConfirmBooking book { get; set; }
        [ForeignKey("userDetails")]
        public int userId { get; set; }
        public UserDetails userDetails { get; set; }
    }
}
