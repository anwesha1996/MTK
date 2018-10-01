using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Employee.DAL.Entity
{
   public class Customer
    {
        [Key]
        public int Customer_ID { get; set; }  


[Required(ErrorMessage = "City required")]  
public string City { get; set; }  


[Required(ErrorMessage = "Contact person required")]  
[DisplayName("Contact person")]  
public string ContactPerson { get; set; }  


[Required(ErrorMessage = "Telephone required")]  
[DisplayName("Telephone")]  
[Phone]  
public string Phone { get; set; }  


[Required(ErrorMessage = "Email required")]  

[EmailAddress]  
public string Email { get; set; }  


public string Notes { get; set; }

    }
}
