using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("ConfirmBooking")]
    public class ConfirmBooking
    {
        [Key]
        public int bookingId { get; set; }
        public DateTime bookingDate { get; set; }
        public DateTime checkInDate { get; set; }
        public DateTime checkOutDate { get; set; }
        public decimal bookingAmount { get; set; }
        public decimal discountAmount { get; set; }
    }
}
