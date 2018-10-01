using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BookingTransfer
    {
        public int roomId { get; set; }
        public int userId { get; set; }
        public DateTime bookingDate { get; set; }
        public DateTime checkInDate { get; set; }
        public DateTime checkOutDate { get; set; }
        public decimal bookingAmount { get; set; }
        public decimal discountAmount { get; set; }
    }
}
