using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Room_allocation.Models
{
	public class UserContext :DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Room> Rooms { get; set; }

		public DbSet<Allocate> Allocates { get; set; }
	}
}