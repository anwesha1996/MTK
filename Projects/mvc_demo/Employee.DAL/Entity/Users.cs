using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DAL.Entity
{
  public class Users
    {
        [Required]  
        public string Name { get; set; } 
 
        [Required]  
        public string Address {get;set;}
  
        [Required]  
        public string Gender { get; set; }

}
}
