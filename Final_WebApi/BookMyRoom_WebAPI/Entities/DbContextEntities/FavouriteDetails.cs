using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("FavouriteDetails")]
  public  class FavouriteDetails
    {
        [Key]
     public   int favId { get; set; }
        [ForeignKey("userDetails")]
        public int userId { get; set; }
        public UserDetails userDetails { get; set; }
        [ForeignKey("hotelDetails")]
        public int hotelId { get; set; }
        public HotelDetails hotelDetails { get; set; }
    }
}
