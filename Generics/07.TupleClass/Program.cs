using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TupleClass
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            CustomTuple<string, string> tupleOne = 
                new CustomTuple<string, string>(input[0] + " " + input[1], input[2]);
            Console.WriteLine(tupleOne);

            input = Console.ReadLine().Split();
            CustomTuple<string, int> tupleTwo = 
                new CustomTuple<string, int>(input[0], int.Parse(input[1]));
            Console.WriteLine(tupleTwo);

            input = Console.ReadLine().Split();
            CustomTuple<int, double> tupleThree = 
                new CustomTuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine(tupleThree);
        }
    }
}
