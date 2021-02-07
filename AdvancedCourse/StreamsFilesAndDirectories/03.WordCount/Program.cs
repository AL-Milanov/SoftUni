using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = Path.Combine("..", "..", "..", "actualResult.txt");
            string[] words = File.ReadAllLines("words.txt");
            Dictionary<string, int> wordsInText = new Dictionary<string, int>();
            string[] text = File.ReadAllLines("text.txt");

            foreach (var word in words)
            {
                wordsInText.Add(word.ToLower(), 0);
            }

            for (int i = 0; i < text.Length; i++)
            {
                string[] currLine = text[i].ToLower()
                    .Split(new string[] {" ", "-", ",", ".", "!", "?", ", " }, 
                    StringSplitOptions.RemoveEmptyEntries);
                
                foreach (var word in currLine)
                {
                    if (wordsInText.ContainsKey(word))
                    {
                        wordsInText[word]++;
                    }
                }
            }

            Dictionary<string, int> sortedWordsCount = wordsInText
                .OrderByDescending(kvp => kvp.Value)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var word in sortedWordsCount)
            {
                File.AppendAllText(outputPath, $"{word.Key} - {word.Value}{Environment.NewLine}");
            }
        }
    }
}
