using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] cmdArgs = command.Split(" : ");
                string course = cmdArgs[0];
                string studentName = cmdArgs[1];

                if (courses.ContainsKey(course) == false)
                {
                    courses.Add(course, new List<string>() { studentName });
                }
                else
                {
                    courses[course].Add(studentName);
                }

                command = Console.ReadLine();
            }

            foreach (var item in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var student in item.Value.OrderBy(x =>x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
