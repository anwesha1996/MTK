using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_Details.Models
{
	public class Employee
	{
		[Required(ErrorMessage = "id is required")]
		public int Employee_ID { get; set; }
		public string EmployeeName { get; set; }
	}
}