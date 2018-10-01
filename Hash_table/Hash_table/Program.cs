using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_table
{



public class ClsPerson
		{
			public string Name;
			public int age;
			public string PlaceOfBirth;

			public ClsPerson(string n, int a, string p)
			{
				Name = n;
				age = a;
				PlaceOfBirth = p;
			}

			public bool CanVote()
			{
				if (age >= 18)
					return true;
				else
					return false;
			}
		}

		public class TestMain
		{
			public static void Main()
			{
				ClsPerson c = new ClsPerson("John", 16, "Chennai");
				ClsPerson c1 = new ClsPerson("Smita", 22, "Delhi");
				ClsPerson c2 = new ClsPerson("Vincet", 25, "Bangalore");
				ClsPerson c3 = new ClsPerson("Jyothi", 10, "Bangalore");
				ClsPerson c4 = new ClsPerson("Jyothi", 10, null);

				c.CanVote();
				c1.CanVote();
				c2.CanVote();
				if (c.CanVote())
					Console.WriteLine(true);
				else
					Console.WriteLine(false);
				if (c1.CanVote())
					Console.WriteLine(true);
				else
					Console.WriteLine(false);
				if (c2.CanVote())
					Console.WriteLine(true);
				else
					Console.WriteLine(false);
				if (c3.CanVote())
					Console.WriteLine(true);
				else
					Console.WriteLine(false);
				if (c4.CanVote())
					Console.WriteLine(true);
				else
					Console.WriteLine(false);


				SortedList s = new SortedList();
				s.Add(c.Name, c.age);
				s.Add(c1.Name, c1.age);
				s.Add(c2.Name, c2.age);
				s.Add(c3.Name, c3.age);
				//s.Add(c4.Name, c4.age);
				ICollection keys = s.Keys;
				foreach (var k in keys)
				{
					Console.Write(k + " " + s[k] + " ");
				}

			Console.ReadKey();

			}
		}
	}
	