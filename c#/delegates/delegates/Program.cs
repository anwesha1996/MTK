using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates
{
	class Program
	{
			public delegate int DelegateHandler(int a, int b);
			static void Main(string[] args)
			{
				Results Results = new Results();
				DelegateHandler sum = new DelegateHandler(Results.sum);
				int result = sum(50, 20);
				Console.WriteLine("Result is: " + result);
				Console.ReadLine();
			}
		}

		public class Results
		{
			public int sum(int a, int b)
			{
				return a + b;
			}
		}
	}

