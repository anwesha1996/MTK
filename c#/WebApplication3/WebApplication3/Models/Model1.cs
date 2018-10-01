namespace WebApplication3.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class Model1 : DbContext
	{
		public Model1()
			: base("name=Model1")
		{
		}

		public virtual DbSet<Entity> Entities { get; set; }
		public virtual DbSet<Student_table2> Student_table2 { get; set; }
		public virtual DbSet<tblStudent> tblStudents { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Entity>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Student_table2>()
				.Property(e => e.StudentName)
				.IsUnicode(false);

			modelBuilder.Entity<tblStudent>()
				.Property(e => e.StudentName)
				.IsUnicode(false);
		}
	}
}
