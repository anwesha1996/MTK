using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GadgetStore.Models
{
    public class Gadget
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GadgetID { get; set; }

        [Required(ErrorMessage = "Please Enter Gadget Name")]
        public string GadgetName { get; set; }

        [Required(ErrorMessage = "Please Enter Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please Upload a Image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Please Enter Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please Enter Quantity")]
        //[Range(1, int.MaxValue, ErrorMessage = "Please enter valid Quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please Enter Double Price")]
       // [Range(1, double.MaxValue, ErrorMessage = "Please enter valid Price")]
        public double Price { get; set; }

    }
}