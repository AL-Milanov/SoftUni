using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());

            Stack<int> gunBarrel = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int valueOfIntelligence = int.Parse(Console.ReadLine());
            int bulletsShot = 0;
            int burrelCap = 0;
            
            while (gunBarrel.Any() && locks.Any())
            {
                int currentLock = locks.Peek();
                int currentBullet = gunBarrel.Pop();
                burrelCap++;
                bulletsShot++;

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (burrelCap == sizeOfGunBarrel && gunBarrel.Any())
                {
                    burrelCap = 0;
                    Console.WriteLine("Reloading!");
                }


            }

            if (locks.Count == 0)
            {
                Console.WriteLine($"{gunBarrel.Count} bullets left. " +
                    $"Earned ${valueOfIntelligence - (priceOfBullet * bulletsShot)}");
            }
            else if (gunBarrel.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
