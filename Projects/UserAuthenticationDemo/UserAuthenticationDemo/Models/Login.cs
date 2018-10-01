using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserAuthenticationDemo.Models
{
    public class Login
    {
       [Display(Name ="UserName")]
       [Required(ErrorMessage ="user name is required")]
        public string UserName { get; set; }

        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}