using System;

namespace _03.CustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] cmdArgs = command
                    .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "Push")
                {
                    for (int i = 1; i < cmdArgs.Length; i++)
                    {
                        stack.Push(int.Parse(cmdArgs[i]));
                    }
                }
                else if (cmdArgs[0] == "Pop")
                {
                    try
                    {

                        stack.Pop();

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }


                command = Console.ReadLine();
            }


            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
