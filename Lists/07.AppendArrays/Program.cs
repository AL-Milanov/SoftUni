using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                                       .Split('|')
                                       .ToList();
            list.Reverse();
            List<string> reversedList = new List<string>();

            foreach (string item in list)
            {
                string[] currItem = item.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (string number in currItem)
                {
                    reversedList.Add(number);
                }
            }
            Console.WriteLine(string.Join(' ', reversedList));
        }
    }
}
