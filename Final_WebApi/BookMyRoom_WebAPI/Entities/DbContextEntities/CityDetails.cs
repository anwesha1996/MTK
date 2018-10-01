using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("CityDetails")]
    public class CityDetails
    {
        [Key]
        public int cityId { get; set; }
        public string cityName { get; set; }

    }
}
