using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Employee.DAL.Entity;

namespace Employee.DAL.DataConnection
{
  public class Datacontext:DbContext
    {
        public Datacontext() :base("name=CustomerConnection")
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
