using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Room_allocation.Models
{
	public class Room
	{
		[Key]
		
		public int RoomId { get; set; }
		[Required(ErrorMessage = "Please enter Rid.")]
		public int Rid { get; set; }
		[Required(ErrorMessage = "Please enter Block_Name.")]

		public string Block_name { get; set; }
		[Required(ErrorMessage = "Please enter Floor_no.")]
		public string Floor_no { get; set; }
	}
}