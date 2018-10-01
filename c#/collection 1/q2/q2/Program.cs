using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace q2
{
	class ClsStudent
	{
		public string name { get; set; }

	}
		public class Program
		{
			static void Main(string[] args)
			{
				ClsStudent cs = new ClsStudent();
				ClsStudent cs1 = new ClsStudent();
				ClsStudent cs2 = new ClsStudent();
				cs.name = "annie";
				cs1.name = "payal";
				cs2.name = "anjali";
				ArrayList a1 = new ArrayList();
				a1.Add(cs.name);
				a1.Add(cs1.name);
				a1.Add(cs2.name);
				for(int i=0;i<a1.Count;i++)
				{
					Console.WriteLine(a1[i]);
				}

				Console.ReadKey();




			}
		}
	}
	

