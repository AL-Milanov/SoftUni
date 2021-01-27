using System;
using System.Collections.Generic;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = Path.Combine("..", "..", "..", "output.txt");
            string[] text = File.ReadAllLines("text.txt");
            
            for (int i = 0; i < text.Length; i++)
            {
                int lettersCount = 0;
                int punctuationCount = 0;

                foreach (var character in text[i])
                {
                    if (char.IsLetter(character))
                    {
                        lettersCount++;
                    }
                    else if (char.IsPunctuation(character))
                    {
                        punctuationCount++;
                    }
                }
                string newLine = $"Line {i + 1}: {text[i]} ({lettersCount})({punctuationCount}){Environment.NewLine}";
                File.AppendAllText(output, newLine);
            }
        }
    }
}
