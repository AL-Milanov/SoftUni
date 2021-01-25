using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("text.txt");

            for (int i = 0; i < text.Length; i++)
            {
                int lettersCount = 0;
                int punctuationCount = 0;
                foreach (var character in text)
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
            }
            File.WriteAllText("output.txt", text);
        }
    }
}
