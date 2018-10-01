using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Room_allocation.Models
{
	public class User
	{
		[Key]
		public int Uid { get; set; }

		[Required(ErrorMessage = "Please enter Mid.")]
		public string Mid { get; set; }
		[Required(ErrorMessage = "Please enter  name.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Please enter track name.")]
		public string Track_name { get; set; }

	}
}