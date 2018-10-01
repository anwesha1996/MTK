using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsDemo
{

    class Demo
    {
        public void Display()
        {
            System.Console.WriteLine("BC::Display");
        }
    }

    class DC : Demo
    {
        new public void Display()
        {
            System.Console.WriteLine("DC::Display");
        }
    }

    class Program
    {
        private int demo = 5;
        static void Main(string[] args)
        {
            Demo b;
            b = new Demo();
            b.Display();
          
        }
    }
}
