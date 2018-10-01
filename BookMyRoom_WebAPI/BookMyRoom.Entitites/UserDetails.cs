using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyRoom.Entitites
{
    public class UserDetails
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Uid { get; set; }
		public string Name { get; set; }
		[Index(IsUnique = true)]
		[MaxLength(40)]
		public string Email { get; set; }
		public string Password { get; set; }

		[Index(IsUnique = true)]
		[MaxLength(20)]
		public string UserName { get; set; }
		public string Gender { get; set; }
		public int Age { get; set; }
		public string Mobile_no { get; set; }


	}
}
