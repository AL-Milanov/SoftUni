using System;
using System.Collections.Generic;

namespace _1.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Dictionary<char, int> charsInString = new Dictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];
                if (letter == ' ')
                {
                    continue;
                }
                if (charsInString.ContainsKey(letter))
                {
                    charsInString[letter]++;
                }
                else
                {
                    charsInString.Add(letter, 1);
                }
            }
            foreach (var item in charsInString)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
