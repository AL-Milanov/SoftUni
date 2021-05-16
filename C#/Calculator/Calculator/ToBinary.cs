using System.Collections.Generic;

namespace MyCalculator
{
    public class ToBinary : Calculator
    {
        public override string Calculate(int number)
        {
            List<int> result = new List<int>();

            while (true)
            {
                int zeroOrOne = number % 2;
                result.Insert(0, zeroOrOne);
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
