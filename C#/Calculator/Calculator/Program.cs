using System;

namespace MyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Binary();

            Console.WriteLine(calculator.Calculate(100));
        }
    }
}
