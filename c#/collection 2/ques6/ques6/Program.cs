using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ques6
{
	public class ClsStudent
	{
		public string name;
		public int age;

		public ClsStudent(string name, int age)
		{
			this.name = name;
			this.age = age;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{

			List<ClsStudent> cs = new List<ClsStudent>()
			{
				new ClsStudent ( "Bill", 14 ),
				new ClsStudent (  "Steve",30 ),
				new ClsStudent (  "Ram",15),
				new ClsStudent (  "Moin",50 )

			};



			foreach (ClsStudent i in cs)
			{
				Console.WriteLine(i.name + " " + i.age);
			}
			Console.ReadKey();
		}
	}
}
