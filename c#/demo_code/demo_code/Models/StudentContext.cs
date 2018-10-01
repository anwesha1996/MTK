using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace demo_code.Models
{
	public class StudentContext :DbContext
	{
		public StudentContext() : base("name = StudentContext")
		{
		}
		public DbSet<Student> Students { get; set; }
	   public DbSet<grades> grades1 { get; set; }

	}
}