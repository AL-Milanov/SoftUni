using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            Dictionary<char, int> charsCount = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (charsCount.ContainsKey(text[i]))
                {
                    charsCount[text[i]]++;
                }
                else
                {
                    charsCount.Add(text[i], 1);
                }
            }

            foreach (var item in charsCount.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
