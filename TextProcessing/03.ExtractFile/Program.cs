using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char[] symbol = new char[] { '\\', '.' };
            string[] arrText = text.Split(symbol);
            string fileExtension = string.Empty;
            string fileName = string.Empty;
            int counter = 0;

            for (int i = arrText.Length - 1; i >= 0; i--)
            {
                if (counter == 1)
                {
                    fileName = arrText[i];
                    break;
                }

                fileExtension = arrText[i];
                counter++;
            }
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
