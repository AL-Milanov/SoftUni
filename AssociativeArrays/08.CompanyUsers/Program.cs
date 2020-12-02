using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> companies = new SortedDictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command.Split(" -> ");
                string company = cmdArgs[0];
                string employeeId = cmdArgs[1];

                if (companies.ContainsKey(company) == false)
                {
                    companies.Add(company, new List<string>() { employeeId });

                }
                else
                {
                    if (companies[company].Contains(employeeId) == false)
                    {
                        companies[company].Add(employeeId);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Key}");
                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
