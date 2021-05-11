using System.Collections.Generic;

namespace MyCalculator
{
    public class Binary : Calculator
    {
        public override string Calculate(int number)
        {
            List<int> result = new List<int>();

            while (true)
            {
                int lastNumber = number % 2;
                result.Insert(0, lastNumber);
                number /= 2;

                if (number == 0)
                {
                    break;
                }
            }

            while (result.Count % 4 != 0)
            {
                result.Insert(0, 0);
            }

            return string.Join("",result);
        }
    }
}
