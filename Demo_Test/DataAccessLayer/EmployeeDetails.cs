using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class EmployeeDetails
    {
		private readonly Db.EmployeeContext employeecontext = new Db.EmployeeContext();

		public void postUser(Employee employee)
		{
			
			employeecontext.employee.Add(employee);
			this.employeecontext.SaveChanges();
		}

    }
}
