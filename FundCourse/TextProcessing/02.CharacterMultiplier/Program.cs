using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            if (text[0].Length <= text[1].Length)
            {
                Console.WriteLine(CharSum(text[0], text[1]));
            }
            else if(text[0].Length > text[1].Length)
            {
                Console.WriteLine(CharSum(text[1], text[0]));
            }

        }

        private static int CharSum(string firstArr, string secondArr)
        {
            int sum = 0;
            for (int i = 0; i < firstArr.Length; i++)
            {
                sum += firstArr[i] * secondArr[i];
                
            }
            for (int i = firstArr.Length; i < secondArr.Length; i++)
            {
                sum += secondArr[i];
            }

            return sum;
        }
    }

    
}
