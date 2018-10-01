using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mvc_demo.Models
{
    [Table("tblDepartment")]
    public class Department
    {
        [Key]
        public int Deparment_ID { get; set; }
        public string Department_Name { get; set; }

        public Employee employee { get; set; }
    }
}