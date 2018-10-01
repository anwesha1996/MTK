using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstSample.Models
{
    public class MIndDBContext : DbContext
    {
        public MIndDBContext() : base("name=MindDBConnection")
        {

        }

        public DbSet<Minds> Minds { get; set; }
        public DbSet<Tracks> Tracks { get; set;}
    }
}