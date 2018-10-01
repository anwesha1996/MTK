using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mvc_demo.Models
{
    [Table("Streams")]
    public class Streams
    {
        [Key]
        public int Stream_ID { get; set; }
        public string Stream_Name { get; set; }

        public Student student { get; set; }
    }
}