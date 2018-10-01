using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Employee_Details.Models;

namespace Employee_Details.Controllers
{
    public class EmployeeDetailsController : ApiController
    {
		public static List<Department> Departments;
		public EmployeeDetailsController()
		{
			Departments = new List<Department>() {
				new Department{ Department_ID = 1,
								DepartmentName = "Computer Science",
								Employees = new List<Employee>{
											new Employee{ Employee_ID = 1, EmployeeName = "John"},
												new Employee{ Employee_ID = 2, EmployeeName = "Martin"}
															}
				},
				new Department{ Department_ID = 2,
								DepartmentName = "Mechanical",
								Employees = new List<Employee>{
												new Employee{ Employee_ID = 3, EmployeeName = "Mathew"},
												new Employee{ Employee_ID = 4, EmployeeName = "albert"}
															}
				}
			};
		}





		[HttpGet]
		public List<Department> GetAllDepartments()
		{
			return Departments;
		}

	}
}
