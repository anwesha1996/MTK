using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace buisness_layer
{
	public class Class1
	{

			public void getdetails()
			{


			Class2 obj = new Class2();
				int s = obj.getDetails();
				if (s > 0)
				{
					Console.WriteLine("data retrieved");
				}
				else Console.WriteLine("data not retrieved");
			}

		
	}
}
