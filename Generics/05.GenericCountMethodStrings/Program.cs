using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> listOfStrings = new List<string>();

            for (int i = 0; i < n; i++)
            {
                listOfStrings.Add(Console.ReadLine());
            }

            string value = Console.ReadLine().Trim();
            
            Box<string> box = new Box<string>(listOfStrings);

            Console.WriteLine(box.CustomCompare(value));
        }
    }
}
