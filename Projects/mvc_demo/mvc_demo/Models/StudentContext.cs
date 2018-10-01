using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace mvc_demo.Models
{
    public class StudentContext :DbContext
    {
        public StudentContext():base("name=StudentConnection")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Streams> Streams { get; set; }
    }
}