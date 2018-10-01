using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class ReviewOutput
    {
        public int rating { get; set; }
        public string review { get; set; }
        public int hotelId { get; set; }
    }
}
