using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            Dictionary<string, int> participants = new Dictionary<string, int>();

            foreach (var name in input)
            {
                participants.Add(name, 0);
            }

            string namePattern = @"([\W\d])";
            string numberPattern = @"([\D])";

            string command = Console.ReadLine();

            while (command != "end of race")
            {
                string name = Regex.Replace(command, namePattern, "");
                string distance = Regex.Replace(command, numberPattern, "");
                int sum = 0;
                foreach (var digit in distance)
                {
                    sum += int.Parse(digit.ToString());
                }
                if (participants.ContainsKey(name))
                {
                    participants[name] += sum;
                }

                command = Console.ReadLine();
            }

            int counter = 1;

            foreach (var racer in participants.OrderByDescending(x=>x.Value))
            {
                string text = counter == 1 ? "st" : counter == 2 ? "nd" : "rd" ;

                Console.WriteLine($"{counter++}{text} place: {racer.Key}");

                if (counter == 4)
                {
                    break;
                }
            }
        }
    }
}
