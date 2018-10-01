using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Output
    {
        public int hotelId { get; set; }
        public int roomId { get; set; }
        public string hotelName { get; set; }
        public string hotelRoomType { get; set; }
        public DateTime hotelFromDate { get; set; }
        public DateTime hotelToDate { get; set; }
        public decimal hotelPrice { get; set; }
        public string hotelCity { get; set; }
        public int hotelRating { get; set; }
        public string hotelAddress { get; set; }

        public static implicit operator Output(List<Output> v)
        {
            throw new NotImplementedException();
        }
    }
}
