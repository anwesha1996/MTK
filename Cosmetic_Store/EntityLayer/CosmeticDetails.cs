using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
	[Table("tbCosmeticDetails")]
	public class CosmeticDetails
    {
		[Key]
		public int Cos_ID { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Cosmetic name is Required")]
		public string Cos_Title { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Company is Required")]
		public string Company { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Category is Required")]
	
		public string Category { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Quantity is Required")]

		public int Quantity { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Price is Required")]

		public int Price { get; set; }
	}
	


	}
