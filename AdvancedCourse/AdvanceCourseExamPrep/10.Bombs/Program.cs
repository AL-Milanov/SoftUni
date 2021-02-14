using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Stack<int> casings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int daturaBomb = 0; //40
            int cherryBomb = 0; //60
            int smokeDecoy = 0; //120

            bool isPouchFull = daturaBomb >= 3 && cherryBomb >= 3 && smokeDecoy >= 3;
            while (effects.Count != 0 && casings.Count != 0)
            {

                isPouchFull = daturaBomb >= 3 && cherryBomb >= 3 && smokeDecoy >= 3;

                if (isPouchFull)
                {
                    break;
                }

                int effectPower = effects.Peek();
                int casingPower = casings.Pop();
                int sum = effectPower + casingPower;

                while (true)
                {
                    bool isCreatedBomb = false;
                    switch (sum)
                    {
                        case 40:
                            daturaBomb++;
                            isCreatedBomb = true;
                            break;
                        case 60:
                            cherryBomb++;
                            isCreatedBomb = true;
                            break;
                        case 120:
                            smokeDecoy++;
                            isCreatedBomb = true;
                            break;
                    }

                    if (isCreatedBomb)
                    {
                        effects.Dequeue();
                        break;
                    }
                    casingPower -= 5;
                    sum = effectPower + casingPower;
                }


            }

            if (isPouchFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (effects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }
            if (casings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBomb}");
            Console.WriteLine($"Datura Bombs: {daturaBomb}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoy}");
        }
    }
}
