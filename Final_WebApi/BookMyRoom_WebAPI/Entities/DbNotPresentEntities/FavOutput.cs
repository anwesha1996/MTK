using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public  class FavOutput
    {
        public int hotelId { get; set; }
        public string hotelName { get; set; }
        public string hotelAddress { get; set; }
        public int starRating { get; set; }
        public decimal price { get; set; }
        public int favId { get; set; }
        public int roomId { get; set; }
        public string imageUrl { get; set; }
    }
}
