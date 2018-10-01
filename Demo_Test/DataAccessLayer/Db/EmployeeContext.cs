using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer.Db
{
	class EmployeeContext : DbContext
	{
		public EmployeeContext() : base ("defaultconnection")
		{

		}

		public DbSet<Employee> employee { get; set; }
	}
}
