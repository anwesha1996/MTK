using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	public class EmployeeContext:DbContext
	{
			public EmployeeContext() : base("name=Crud")
			{

			}

			public DbSet<Employee> Employees { get; set; }
			
	}
}