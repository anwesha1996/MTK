using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ques1
{
	public class Program
	{
		static void Main(string[] args)
		{
			int r;
			int sum = 0;
			int mid;
			ArrayList a = new ArrayList();
			Double avg;
			bool acceptFlag = false;
			while (!acceptFlag)
			{

				Console.WriteLine("Enter some integer");
			int i = int.Parse(Console.ReadLine().ToString());
				Console.WriteLine("Do you want to continue? Y/N");
				char accept = char.Parse(Console.ReadLine().ToString().ToUpper());

				if (accept == 'Y')
				{

					acceptFlag = true;
					a.Add(i);
				}
				else
				{
					acceptFlag = false;
				}
			}
			foreach (int l in a)
			{
				Console.WriteLine(l);
			}
			Console.WriteLine();
			foreach (int l in a)
			{
				sum = sum + l;
			}
			Console.WriteLine();
			avg = sum / a.Count;
			if (a.Count % 2 == 0)
			{
				mid = ((a.Count / 2) + 1);
			}

			else mid = a.Count / 2;
			a.Insert(mid, avg);
			foreach (int i in a)
			{
				Console.WriteLine(i);
			}
			Console.WriteLine();
			a.RemoveAt(mid);
			foreach (int i in a)
			{
				Console.WriteLine(i);
			}
			Console.ReadKey();


		}
	}
}
