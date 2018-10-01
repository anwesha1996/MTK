using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApidemo.Models
{
	public class Products
	{
		
			[Required(ErrorMessage = "id is required")]
			public int ID { get; set; }
			public string ProductName { get; set; }
			public ICollection<Customer> Customers { get; set; }
		

	}
}