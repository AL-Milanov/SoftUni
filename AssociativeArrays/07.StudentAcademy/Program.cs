using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string nameOfStudent = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(nameOfStudent) == false)
                {
                    students.Add(nameOfStudent, new List<double>() { grade });
                }
                else
                {
                    students[nameOfStudent].Add(grade);
                }
            }
            Dictionary<string, double> bestStudents = new Dictionary<string, double>();
            foreach (var student in students)
            {
                double average = student.Value.Average();
                bestStudents.Add(student.Key, average);
            }

            foreach (var student in bestStudents.OrderByDescending(x => x.Value))
            {
                if (student.Value >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value:f2}");
                }
            }
        }
    }
}
