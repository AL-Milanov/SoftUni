using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> listOfStrings = new List<double>();

            for (int i = 0; i < n; i++)
            {
                listOfStrings.Add(double.Parse(Console.ReadLine()));
            }

            double value = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>(listOfStrings);

            Console.WriteLine(box.CustomCompare(value));
        }
    }
}
