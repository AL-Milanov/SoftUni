using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                      .Split()
                                      .Select(int.Parse)
                                      .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] cmdArg = command.Split();
                string firstCommand = cmdArg[0];
                int secoundCommand = int.Parse(cmdArg[1]);

                if (firstCommand == "Delete")
                {
                    numbers.RemoveAll(n => n == secoundCommand);
                }
                else
                {
                    int thirdCommand = int.Parse(cmdArg[2]);
                    numbers.Insert(thirdCommand, secoundCommand);
                }


                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
