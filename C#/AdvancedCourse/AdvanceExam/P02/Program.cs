using System;
using System.Collections.Generic;
using System.Linq;

namespace P02
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());

            Queue<int> defense = new Queue<int>(Console.ReadLine()
                                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                       .Select(int.Parse)
                                                       .ToArray());

            Stack<int> orcs = new Stack<int>();
            int count = 0;

            for (int i = 0; i < numberOfWaves; i++)
            {
                count++;
                orcs = new Stack<int>(Console.ReadLine()
                                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse)
                                                .ToArray());

                int orcAttack = orcs.Peek();
                int defensePlate = defense.Peek();


                if (count % 3 == 0)
                {
                    defense.Enqueue(int.Parse(Console.ReadLine()));
                    count = 0;
                }

                while (defense.Count > 0 && orcs.Count > 0)
                {

                    if (orcAttack == defensePlate)
                    {
                        defensePlate -= orcAttack;
                        orcs.Pop();
                        defense.Dequeue();

                        if (defense.Count > 0 && orcs.Count > 0)
                        {
                            orcAttack = orcs.Peek();
                            defensePlate = defense.Peek();
                        }

                    }
                    else if (orcAttack > defensePlate)
                    {
                        orcAttack -= defensePlate;
                        defense.Dequeue();

                        if (defense.Count > 0)
                        {
                            defensePlate = defense.Peek();
                        }
                    }
                    else if (defensePlate > orcAttack)
                    {
                        defensePlate -= orcAttack;
                        orcs.Pop();

                        if (orcs.Count > 0)
                        {
                            orcAttack = orcs.Peek();

                        }
                    }

                }

                if (defense.Count == 0)
                {

                    orcs.Pop();
                    orcs.Push(orcAttack);
                    break;
                }
                if (defensePlate > 0)
                {
                    defense.Dequeue();
                    defense = new Queue<int>(defense.Reverse());
                    defense.Enqueue(defensePlate);
                    defense = new Queue<int>(defense.Reverse());
                }

            }

            if (orcs.Count == 0) //?
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {String.Join(", ", defense)}");

            }
            else if (defense.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {String.Join(", ", orcs)}");
            }
        }
    }
}
