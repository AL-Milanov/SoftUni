using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryMats = new Dictionary<string, int>();
            SortedDictionary<string, int> commonMats = new SortedDictionary<string, int>();
            legendaryMats.Add("shards", 0);
            legendaryMats.Add("fragments", 0);
            legendaryMats.Add("motes", 0);

            bool isObtained = false;

            while (isObtained == false)
            {

                string[] materials = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < materials.Length - 1; i++)
                {
                    int quantity = int.Parse(materials[i]);
                    string type = materials[i + 1].ToLower();
                    i++;

                    if (type == "shards" || type == "fragments" || type == "motes")
                    {
                        legendaryMats[type] += quantity;
                        if (legendaryMats[type] >= 250)
                        {
                            switch (type)
                            {
                                case "shards":
                                    Console.WriteLine("Shadowmourne obtained!");
                                    break;
                                case "fragments":
                                    Console.WriteLine("Valanyr obtained!");
                                    break;
                                case "motes":
                                    Console.WriteLine("Dragonwrath obtained!");
                                    break;

                            }
                            legendaryMats[type] -= 250;
                            isObtained = true;
                            break;
                        }
                    }
                    else
                    {
                        if (commonMats.ContainsKey(type) == false)
                        {
                            commonMats.Add(type, quantity);
                        }
                        else
                        {
                            commonMats[type] += quantity;
                        }
                    }

                }
                
            }
            foreach (var item in legendaryMats.OrderByDescending(x => x.Value).ThenBy(x=> x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in commonMats)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
