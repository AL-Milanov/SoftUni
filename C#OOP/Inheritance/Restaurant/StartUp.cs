using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Cake cake = new Cake("Qgodova");
            Tea team = new Tea("Shipka", 9.9999M, 10.2);
            Fish fish = new Fish("Caca", 2.22M);
            Console.WriteLine(fish.Grams);
            Console.WriteLine(cake.Price);
        }
    }
}