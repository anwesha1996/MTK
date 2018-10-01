using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace q5
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

		public class Program
		{
			public static void Main()
			{
				ClsPerson c = new ClsPerson("John", 16, "Chennai");
				ClsPerson c1 = new ClsPerson("Smita", 22, "Delhi");
				ClsPerson c2 = new ClsPerson("Vincet", 25, "Bangalore");
				ClsPerson c3 = new ClsPerson("Jyothi", 10, "Bangalore");


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
				


				Hashtable ht = new Hashtable();
				ht.Add(c.Name, c.age);
				ht.Add(c1.Name, c1.age);
				ht.Add(c2.Name, c2.age);
			    ht.Add(c3.Name, c3.age);
			
				ICollection keys = ht.Keys;
				foreach (var k in keys)
				{
					Console.Write(k + " " + ht[k] + " ");
				}
				Console.ReadKey();



			}
		}
	}
	