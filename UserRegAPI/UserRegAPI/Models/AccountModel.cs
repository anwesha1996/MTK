using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserRegAPI.Models
{
	public class AccountModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Gender { get; set; }
		public string Age { get; set; }
		public string Mobile_no { get; set; }
	}
}