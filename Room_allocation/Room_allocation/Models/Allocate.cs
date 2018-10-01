using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Room_allocation.Models
{
	public class Allocate
	{
		[Key]
		public int A_Id { get; set; }
		
		public int Uid { get; set; }
		[ForeignKey("Uid")]
		public User User { get; set; }

		
		public int RoomId { get; set; }
		[ForeignKey("RoomId")]
		public Room Room { get; set; }

	}
}