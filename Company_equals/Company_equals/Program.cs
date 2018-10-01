using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_equals
{


class Current : Object
		{
			public string companyName { set; get; }
			public string typeOfBusiness { set; get; }
			public string website { set; get; }
			public string contactName { set; get; }

			public Current storeData(Current c)
			{
				Console.WriteLine("enter the company name");
				c.companyName = Console.ReadLine();
				return c;
			}
			public override bool Equals(Object ob)
			{
				Current r = (Current)ob;
				if (this.companyName == r.companyName)
					return true;
				else return false;
			}

		}

		public class Test
		{
			public static void Main()
			{

				Current v = new Current();
				Current v1 = new Current();
				v.storeData(v);
				v1.storeData(v1);
				if (v.Equals(v1))
				{
					Console.WriteLine("True");
				}
			}
	}
}
