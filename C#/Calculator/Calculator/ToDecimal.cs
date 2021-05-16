using System;

namespace MyCalculator
{
    public class ToDecimal : Calculator
    {
        public override string Calculate(int number)
        {
            double sum = 0.0;
            string binaryNumber = number.ToString();
            double powNumber = 0.0;

            for (int i = binaryNumber.Length - 1; i >= 0; i--)
            {
                int currentNumber = int.Parse(binaryNumber[i].ToString());

                sum += currentNumber * Math.Pow(2, powNumber);

                powNumber++;
            }

            return sum.ToString();
        }
    }
}
