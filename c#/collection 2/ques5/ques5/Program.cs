using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ques5

{
	class Person
	{
		public string Name { get; set; }
	}
	public class Test
	{

		static void Main(string[] args)
		{
			Person obj1 = new Person();
			obj1.Name = "John";

			Person obj2 = new Person();
			obj2.Name = "Bill";

			Person obj3 = new Person();
			obj3.Name = "Dell";

			Person obj4 = new Person();
			obj4.Name = "Misha";

			ArrayList list = new ArrayList();
			int c = 0;
			list.Add(obj1);
			list.Add(obj2);
			list.Add(obj3);
			list.Add(obj4);
			list.Add("123");

			try
			{
				foreach (Person p in list)
				{

					Console.WriteLine(p.Name);
					c++;

				}
			}
			catch
			{
				Console.WriteLine(list[c]);
			}
			
		}
	}
}
