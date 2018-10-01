using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBasics
{
    //
    public delegate string DelegateDemo(string firstName, string lastName);
    class Program
    {
        public static string Details(string fName, string lName)
        {
            return fName + lName;
        }

        public static string Designation(string des,string program)
        {
            return program + des;
        }
        static void Main(string[] args)
        {
            DelegateDemo delObj = new DelegateDemo(Details);
            delObj += new DelegateDemo(Designation);
            Console.WriteLine("Please enter your details");
            string fname = Console.ReadLine();
            string lName = Console.ReadLine();
            string program = Console.ReadLine();
            string designation = Console.ReadLine();

            string res = delObj(fname, lName);
          
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
