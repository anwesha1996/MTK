using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Demo_Async.Models
{
	public class MyDB :DbContext
	{
		public DbSet<Department> Departments { get; set; }
	}
}