using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public delegate int MyDelegate(int a, int b);
        static void Main(string[] args)
        {
            Results Results = new Results();
            MyDelegate summation = new MyDelegate(Results.sum);
            int result = summation(50, 20);
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

