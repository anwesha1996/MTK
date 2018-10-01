using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer.DbContext
{
	public class CosDetailsDBContext : System.Data.Entity.DbContext
	{
		public CosDetailsDBContext() : base("name = CosmeticStore")
		{

		}

		/// <summary>
		/// List of all Books
		/// </summary>
		public virtual DbSet<CosmeticDetails> cosmeticDetails { get; set; }

	}
}
