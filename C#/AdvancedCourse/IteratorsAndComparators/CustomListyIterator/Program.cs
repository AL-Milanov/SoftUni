using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ListyIterator<string> listOfData = new ListyIterator<string>(input.Skip(1));

            string command = Console.ReadLine();
            
            while (command != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(listOfData.Move());
                }
                else if (command == "Print")
                {
                    listOfData.Print();
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listOfData.HasNext());
                }
                command = Console.ReadLine();
            }
        }
    }
}
