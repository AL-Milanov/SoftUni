using System;
using System.Runtime.InteropServices.ComTypes;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            double biscuits = double.Parse(Console.ReadLine());
            double workers = double.Parse(Console.ReadLine());
            double total = 0;
            double biscuitsOnTrird = biscuits * 0.75;
            int competingFactory = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 30; i++)
            {
                if ( i % 3 == 0)
                {
                    total += Math.Floor(biscuitsOnTrird * workers);
                }
                else
                {
                    total += biscuits * workers;
                }
            }
            Console.WriteLine($"You have produced {total} biscuits for the past month.");
            double diff = 0.0;
            double percent = 0.0;
            if (total > competingFactory)
            {
                diff = total - competingFactory;
                percent = (diff / competingFactory) * 100;
                Console.WriteLine($"You produce {percent:f2} percent more biscuits.");
            }
            else
            {
                diff = competingFactory - total;
                percent = (diff/competingFactory) * 100;
                Console.WriteLine($"You produce {percent:f2} percent less biscuits.");
            }
        }
    }
}
