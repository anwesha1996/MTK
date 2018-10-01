using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_Details.Models
{
	public class Department
	{

		[Required(ErrorMessage = "id is required")]
		public int Department_ID { get; set; }
		public string DepartmentName { get; set; }
		public ICollection<Employee> Employees { get; set; } 
	}
}