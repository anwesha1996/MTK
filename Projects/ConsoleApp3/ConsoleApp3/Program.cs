using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5];
            int[] b = new int[5];
            int d = 2;

            try
            {
                for (int i = 0; i < a.Length; i++)
                {
                    
                    int c = d / 0;
                    //b = a;
                    //Console.WriteLine(b);
                }

                a.CopyTo(b, 0);

                for (int i = 0; i < b.Length; i++)
                {
                    //a[i] = 2;
                    ////b = a;
                    Console.WriteLine(b);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("error");
            }
            Console.WriteLine("executed");
        }
    }
}
