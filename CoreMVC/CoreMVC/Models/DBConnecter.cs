using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;


namespace CoreMVC.Models
{
    public class DBConnecter:DbContext 
    {
        public DbSet<Mind> CampusMinds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=A2ML13899;Initial Catalog=Minds;Integrated Security=True;MultipleActiveResultSets=True");
        }
    }
}
