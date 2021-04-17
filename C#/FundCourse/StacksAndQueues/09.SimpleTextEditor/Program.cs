using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < numberOfOperations; i++)
            {
                string command = Console.ReadLine();
                string[] cmdArgs = command.Split();
                string token = cmdArgs[0];
                if (token == "1")
                {
                    stack.Push(text);
                    text += cmdArgs[1];
                }
                else if (token == "2")
                {
                    int count = int.Parse(cmdArgs[1]);
                    if (count <= text.Length)
                    {
                        stack.Push(text);
                        for (int j = 0; j < count; j++)
                        {
                            text = text.Remove(text.Length - 1);
                        }
                    }
                }
                else if (token == "3")
                {
                    int index = int.Parse(cmdArgs[1]);
                    if (index <= text.Length)
                    {
                        Console.WriteLine(text[index - 1]);
                    }
                }
                else if (token == "4")
                {
                    text = stack.Peek();
                    stack.Pop();
                }

            }
        }
    }
}
