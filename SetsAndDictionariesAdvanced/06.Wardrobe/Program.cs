using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] cloth = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (wardrobe.ContainsKey(color) == false)
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    
                }
                for (int j = 0; j < cloth.Length; j++)
                {
                    if (wardrobe[color].ContainsKey(cloth[j]))
                    {
                        wardrobe[color][cloth[j]]++;
                    }
                    else
                    {
                        wardrobe[color].Add(cloth[j], 1);
                    }

                }

            }
            string[] neededClothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorIWant = neededClothes[0];
            string clothIWant = neededClothes[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine(item.Key + " clothes:");
                foreach (var dress in item.Value)
                {
                    Console.Write($"* {dress.Key} - {dress.Value}");
                    if (colorIWant == item.Key && clothIWant == dress.Key)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
