using System;

namespace MyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new ToDecimal();

            Console.WriteLine(calculator.Calculate(1111101000));
        }
    }
}
