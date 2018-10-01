using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace q4
{
	class Program
	{
		static void Main(string[] args)
			{
				Stack st = new Stack();
				st.Push("string 1");
				st.Push("string 2");
				st.Push("string 4");
				st.Push("string 5");
				st.Pop();
				st.Pop();
				st.Push("string 3");
				st.Push("string 4");
				st.Push("string 5");

				foreach (var i in st)
				{
					Console.Write(i + " ");

				}
				Console.WriteLine();
				Console.WriteLine("the topmost item ={0}", st.Peek());
			Console.ReadKey();
			}
		}

	}

