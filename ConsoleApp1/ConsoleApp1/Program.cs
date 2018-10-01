using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class InvalidSumException : Exception
	{
		public InvalidSumException(String message)
			: base(message)
		{

		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			IDictionary<int, int> dict = new Dictionary<int, int>();
			dict.Add(1,1);
			dict.Add(2,4);
			dict.Add(3,5);
			dict.Add(4,2);
			dict.Add(5,8);
			int sum = 0;

			foreach (var i in dict)
			{
				sum = sum + i.Value;
				//Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
			}
			try
			{
				if (sum < 5)
				{
					Console.WriteLine("sum=", sum);
				}
				else throw new InvalidSumException("summation not required");
			}
			catch (InvalidSumException e)
			{
				Console.WriteLine(e);
			}
			Console.WriteLine("Rest of the code");


				//Console.WriteLine(sum);
			Console.ReadKey();
		}
	}
}
