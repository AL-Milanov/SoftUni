using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _12.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberPattern = @"\d";
            string emojiPattern = @"(:{2}|\*{2})[A-z][a-z]{2,}\1";
            Regex numberRegex = new Regex(numberPattern);
            Regex emojiRegex = new Regex(emojiPattern);

            string text = Console.ReadLine();
            long coolThreshold = 1;
            numberRegex.Matches(text)
                       .Select(m => m.Value)
                       .Select(int.Parse)
                       .ToList()
                       .ForEach(x => coolThreshold *= x);
            

            var emojiMatches = emojiRegex.Matches(text);
            int counter = emojiMatches.Count;
            List<string> coolEmojis = new List<string>();

            foreach (Match emoji in emojiMatches)
            {
                long coolness = emoji.Value
                    .Substring(2, emoji.Value.Length - 4)
                    .ToCharArray()
                    .Sum(x => (int)x);

                if (coolness > coolThreshold)
                {
                    coolEmojis.Add(emoji.Value);
                }

            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{counter} emojis found in the text. The cool ones are:");

            foreach (var emoji in coolEmojis)
            {
                Console.WriteLine(emoji);
            }

        }
    }
}
