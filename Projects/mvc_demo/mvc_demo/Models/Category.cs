using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mvc_demo.Models
{
    [Table("tblCategories")]
    public class Category
    {
        [Key]
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
    }
}