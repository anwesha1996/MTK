using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mvc_demo.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int Student_ID { get; set; }
        public string Student_Name { get; set; }
    }
}