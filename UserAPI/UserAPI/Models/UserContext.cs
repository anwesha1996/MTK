﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UserAPI.Models
{
	public class UserContext:DbContext
	{
		public DbSet<UserDetail> UserDetails { get; set; }
	}
}