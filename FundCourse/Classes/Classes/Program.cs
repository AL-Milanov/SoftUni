using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            int lastRngNum = 0;
            for (int i = 0; i < 6; i++)
            {
                int randomNum = rng.Next(1, 50);
                if (lastRngNum == randomNum)
                {
                    i--;

                }
                else
                {

                    Console.Write(randomNum + " ");
                }
                lastRngNum = randomNum;
            }
        }
    }
}
