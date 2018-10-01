using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ques7
{
	class ClsStudent
	{
		public string name;
	}
	
	class Program
	{
		static void Main(string[] args)
		{
				Dictionary<string, ClsStudent> dict = new Dictionary<string, ClsStudent> ();
				ClsStudent obj1 = new ClsStudent();
			ClsStudent obj2 = new ClsStudent();
			ClsStudent obj3 = new ClsStudent();
			ClsStudent obj4 = new ClsStudent();
			ClsStudent obj5 = new ClsStudent();
			obj1.name = "John";
			obj2.name = "Bill";
			obj3.name = "Meeta";
			obj4.name = "Jolly";
			obj5.name = "Bill";
			try
			{
				dict.Add(obj1.name, obj1);
				dict.Add(obj2.name, obj2);
				dict.Add(obj3.name, obj3);
				dict.Add(obj4.name, obj4);
				dict.Add(obj5.name, obj5);
			}
			catch
			{
				Console.WriteLine("cannot add a item with duplicate key");
			}

			foreach (KeyValuePair<string, ClsStudent> i in dict)
			{
				if (i.Key == "Meeta")
				{
					Console.WriteLine("Key: {0}, Value: {1}", i.Key, i.Value);
				}
			}
			Console.ReadKey();

		}
	}
}
