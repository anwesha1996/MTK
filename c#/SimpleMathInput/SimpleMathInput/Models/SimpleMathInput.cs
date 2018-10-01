using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMathInput.Models
{
	public class SimpleMathInput
	{
		public int fno { get; set; }
		public int sno { get; set; }

		public string GetResult()
		{
			string res = string.Empty;
			res = string.Format("sum={0} ", fno + sno);
			return res;
			
		}

	}
}