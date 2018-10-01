using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialsubstring
{
    class Program
    {
        static int getSpecialSubstring(string s, int k, string charValue)
        {

            //for(int i=0; i<charValue.Length;i++)
            //{
            //    y = charValue[i];
            //    Console.WriteLine(y);
            //}
            //foreach(char z in charValue)
            //{
            //    Console.WriteLine(z);
            //}
            var alphabet = Enumerable.Range(0, 26).Select(i => Convert.ToChar('A' + i));

            foreach(char c in alphabet)
            {
                Console.WriteLine(c);
            }
            return 0;
        }
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            int k = Convert.ToInt32(Console.ReadLine());

            string charValue = Console.ReadLine();

            int res = getSpecialSubstring(s, k, charValue);

            Console.WriteLine(res);
        }
    }
}
