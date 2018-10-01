using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace BuisnessLayer
{
    public class EmployeeManager
    {
		private readonly EmployeeDetails employeedetails = new EmployeeDetails();


		public void PostUser(Employee employee)
		{
			employeedetails.postUser(employee);
		}


    }
}
