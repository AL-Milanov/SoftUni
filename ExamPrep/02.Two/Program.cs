using System;
using System.Linq;

namespace _02.Two
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleLeft = int.Parse(Console.ReadLine());
            int[] wagons = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < wagons.Length; i++)
            {
                if (peopleLeft == 0)
                {
                    break;
                }
                while (wagons[i] < 4)
                {
                    wagons[i]++;
                    peopleLeft--;
                    if (peopleLeft == 0)
                    {
                        break;
                    }
                }
            }

            int isThereEmptySpaces = wagons.Count(x=>x != 4);

            if (isThereEmptySpaces > 0 && peopleLeft <= 0)
            {
                Console.WriteLine($"The lift has empty spots!");
                Console.WriteLine(string.Join(" ", wagons));

            }
            else if(peopleLeft > 0)
            {
                Console.WriteLine($"There isn't enough space! {peopleLeft} people in a queue!");
                Console.WriteLine(string.Join(" ", wagons));
            }
            else 
            {
                Console.WriteLine(string.Join(" ", wagons));
            }
        }
    }
}
