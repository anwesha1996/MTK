using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace demo_code.Models
{
	public class grades
	{
		[Key]
		public int Gradeid { get; set; }
		public string Name { get; set; }

	}
}