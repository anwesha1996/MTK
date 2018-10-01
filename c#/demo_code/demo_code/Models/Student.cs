using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demo_code.Models
{
	public class Student
	{
		[Key]
		public int Id { get; set; }
		public string Stud_Name { get; set; }
		public string Address { get; set; }


		//[ForeignKey("Gradeid")]
		public int Gradeid { get; set; }
		[ForeignKey("Gradeid")]
		public grades grades { get; set; }
	}
}