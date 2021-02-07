using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                symbol += (char)3;
                sb.Append(symbol);
            }
            Console.WriteLine(sb);
        }
    }
}
