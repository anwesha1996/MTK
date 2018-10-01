using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Review
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reviewId { get; set; }

        public int rating { get; set; }

        [MaxLength(150)]
        public string review { get; set; }

        [ForeignKey("hotelDetails")]
        public int hotelId { get; set; }
        public HotelDetails hotelDetails { get; set; }
    }
}
