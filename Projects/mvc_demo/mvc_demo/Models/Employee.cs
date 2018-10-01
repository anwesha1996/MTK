using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mvc_demo.Models
{
    [Table("tbEmployee")]
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; }
        public string Employee_Name { get; set; }
    }
}