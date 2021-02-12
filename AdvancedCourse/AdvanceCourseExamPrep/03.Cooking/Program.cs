using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;


            while (liquids.Count > 0 && ingredients.Count > 00)
            {

                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Peek();
                int sum = liquid + ingredient;

                bool isIncreased = false;
                while (true)
                {
                    switch (sum)
                    {
                        case 25:
                            breadCount++;
                            isIncreased = true;
                            break;
                        case 50:
                            cakeCount++;
                            isIncreased = true;
                            break;
                        case 75:
                            pastryCount++;
                            isIncreased = true;
                            break;
                        case 100:
                            fruitPieCount++;
                            isIncreased = true;
                            break;
                    }

                    ingredient += 3;

                    if (isIncreased || liquids.Count == 0)
                    {
                        break;
                    }
                    liquid = liquids.Dequeue();
                    sum = liquid + ingredient;

                }
                if (isIncreased)
                {
                    ingredients.Pop();
                    continue;
                }

                ingredients.Pop();
                ingredients.Push(ingredient);
            }

            bool isCompleteOrder = breadCount != 0 && cakeCount != 0 &&
                                   fruitPieCount != 0 && pastryCount != 0;

            if (isCompleteOrder)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            string liquidsResult = "Liquids left: ";
            string ingredientsResult = "Ingredients left: ";

            liquidsResult += liquids.Count == 0 ? "none" : string.Join(", ", liquids);
            ingredientsResult += ingredients.Count == 0 ? "none" : string.Join(", ", ingredients);

            Console.WriteLine(liquidsResult);
            Console.WriteLine(ingredientsResult);

            Console.WriteLine($"Bread: {breadCount}");
            Console.WriteLine($"Cake: {cakeCount}");
            Console.WriteLine($"Fruit Pie: {fruitPieCount}");
            Console.WriteLine($"Pastry: {pastryCount}");
        }
    }
}
