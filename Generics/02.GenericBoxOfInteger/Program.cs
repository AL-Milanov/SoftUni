using System;

namespace _02.GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var data = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(data);
                Console.WriteLine(box);
            }
        }
    }
}
