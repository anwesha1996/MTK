using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList_1
{
	public class Program
	{
		static void Main(string[] args)
		{
	
				int i, r, sum = 0, mid; Double avg;
				ArrayList a = new ArrayList();
				Console.WriteLine("Enter some integer");
				for (r = 1; r <= 5; r++)
				{
					i = int.Parse(Console.ReadLine().ToString());
					a.Add(i);
					sum += i;
				}
				avg = sum / 5;
				mid = 5 / 2;


				a.Insert(mid, avg);
				a.RemoveAt(mid);


				int c = a.Count;
				Console.WriteLine("no of elements in an array " + c);
				foreach (var j in a)
				{
					Console.Write(j + " ");
				}
			Console.ReadKey();

			}


		}

	}

