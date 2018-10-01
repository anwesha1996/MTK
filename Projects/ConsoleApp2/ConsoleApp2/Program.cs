using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static string[] doesCircleExist(string[] commands)
        {

            int dir = 0;
            var result = new List<string>();
            // Traverse the path 
            // given for robot
            for (int i = 0; i < commands.Length; i++)
            {
                int x = 0, y = 0;
                // Find current move
                char[] move = new char[commands.Length];

                move = commands[i].ToCharArray();

                foreach (char moves in move)
                {
                    // If move is left or
                    // right, then change direction
                    if (moves == 'R')
                        dir = (dir + 1) % 4;
                    else if (moves == 'L')
                        dir = (4 + dir - 1) % 4;

                    // If move is Go, then 
                    // change x or y according to
                    // current direction
                    // if (move == 'G')
                    else
                    {
                        if (dir == 0)
                            y++;
                        else if (dir == 1)
                            x++;
                        else if (dir == 2)
                            y--;
                        else // dir == 3
                            x--;
                    }
                                       
                }
                if (x == 0 && y == 0)

                {
                    result.Add("Yes");
                }
                else
                {
                    result.Add("NO");
                }
            }

            // If robot comes back to
            // (0, 0), then path is cyclic

            return result.ToArray();
        }


        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int commandsCount = Convert.ToInt32(Console.ReadLine());

            string[] commands = new string[commandsCount];

            for (int i = 0; i < commandsCount; i++)
            {
                string commandsItem = Console.ReadLine();
                commands[i] = commandsItem;
            }

            string[] res = doesCircleExist(commands);

            Console.WriteLine(res);
            //textWriter.WriteLine(string.Join("\n", res));

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
