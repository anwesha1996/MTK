using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstSample.Models
{
    [Table("tbMinds")]
    public class Minds
    {
        [Key]
        public int MID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        
        public Tracks trackDetails { get; set; }
    }
}