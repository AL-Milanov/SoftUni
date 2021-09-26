using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MobileX
{
    public class Program
    {
        static void Main(string[] args)
        {
            var items = new List<bool>();

            foreach (var item in items.OrderByDescending(t => t))
            {
                Console.WriteLine(item);
            }
        }
    }
}
