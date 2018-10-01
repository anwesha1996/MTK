using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternateParityPermutation
{
    class Program
    {
        public static void swapTwoNumber(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static void alternatingPermutations(int n)
        {

            int[] list = new int[n];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                Console.Write(" element - {0} : ", i);
                list[i] = Convert.ToInt32(Console.ReadLine());
            }

          var finalArr=  alternatingParityPermutations(list, k, n);

            Console.Write("\n\n");
        }

        public static int[] alternatingParityPermutations(int[] list, int k, int n)
        {
            List<int> parityPerm = new List<int>();
            List<int> parityPermFinal = new List<int>();
            int[,] alterArray = new int[n,n];
            if (k == n)
            {
                bool loop = false;
                for (int i = 0; i < n; i++)
                {
                    parityPerm.Add(list[i]);
                    Console.Write("{0}", list[i]);
                    Console.Write(" ");
                }

                var arr = parityPerm.ToArray();


                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if ((arr[i] % 2 == 0 && arr[j] % 2 == 0) || (arr[i] % 2 != 0 && arr[j] % 2 != 0))
                        {
                            loop = true;
                            break;
                        }
                        else if ((arr[i] % 2 == 0 && arr[j] % 2 != 0) || (arr[i] % 2 != 0 && arr[j] % 2 == 0))
                        {
                            parityPermFinal.Add(arr[i]);
                            break;
                        }
                    }
                    if (loop)
                    {
                        parityPermFinal.Clear();
                        break;

                    }
                    if (i + 1 >= arr.Length && parityPermFinal.Count != 0)
                    {
                        parityPermFinal.Add(arr[i]);
                    }
                }   
                var finalArr = parityPermFinal.ToArray();
            }

            else
            {
                for (int i = k; i < n; i++)
                {
                    swapTwoNumber(ref list[k], ref list[i]);
                    alternatingParityPermutations(list, k + 1, n);
                    swapTwoNumber(ref list[k], ref list[i]);
                }
            }
            return finalArr;
        }
        static void Main(string[] args)

        {
            int n = Convert.ToInt32(Console.ReadLine());
            alternatingPermutations(n);


        }
    }
}
