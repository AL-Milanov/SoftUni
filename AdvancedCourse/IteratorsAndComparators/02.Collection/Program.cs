using System;
using System.Linq;

namespace _02.Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ListyIterator<string> listyIterator = new ListyIterator<string>(input.Skip(1));

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (command == "Print")
                {
                    listyIterator.Print();
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else if (command == "PrintAll")
                {
                    foreach (var item in listyIterator)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }

                command = Console.ReadLine();
            }
        }
    }
}
