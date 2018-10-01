using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingPairs
{
    class Program
    {
        static void Main(string[] args)
        {
           // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int numbersCount = Convert.ToInt32(Console.ReadLine());

            int[] numbers = new int[numbersCount];

            for (int i = 0; i < numbersCount; i++)
            {
                int numbersItem = Convert.ToInt32(Console.ReadLine());
                numbers[i] = numbersItem;
            }

            int k = Convert.ToInt32(Console.ReadLine());

            int res = countPairs(numbers, k);


            Console.WriteLine(res);
        }

        static int countPairs(int[] numbers, int k)
        {
            int count = 0;
            int n = numbers.Length;
            // Sort array elements
            Array.Sort(numbers);

            int l = 0;
            int r = 0;
            while (r < n)
            {
               if(r+1< n && numbers[r]==numbers[r+1])
                {
                    r++;
                }
                if (l+1<n && numbers[l] == numbers[l + 1])
                {
                    l++;
                }
                if (numbers[r] - numbers[l] == k)
                    {
                        
                            count++;
                            l++;
                            r++;
                        
                    }
                    else if (numbers[r] - numbers[l] > k)
                        l++;
                    else // arr[r] - arr[l] < sum
                        r++;
               
            }
            Console.WriteLine(count);
            return count;


        }
    }
}
