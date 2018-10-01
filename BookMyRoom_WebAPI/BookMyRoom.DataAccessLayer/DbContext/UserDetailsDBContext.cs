using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyRoom.Entitites;

namespace BookMyRoom.DataAccessLayer.DbContext
{
	class UserDetailsDBContext : System.Data.Entity.DbContext
	{
		public UserDetailsDBContext() : base("name = UserContext")
        {

		}
		public DbSet<UserDetails> userDetails { get; set; }
	}
}
