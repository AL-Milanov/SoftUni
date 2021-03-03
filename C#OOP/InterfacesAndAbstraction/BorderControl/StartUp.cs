using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Id> citizensAndRobots = new List<Id>();
            while (input != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string nameOrModel = data[0];
                
                if (data.Length == 3)
                {
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    Citizen citizen = new Citizen(nameOrModel, age, id);
                    citizensAndRobots.Add(citizen);
                }
                else if (data.Length == 2)
                {
                    string id = data[1];
                    Robot robot = new Robot(nameOrModel, id);
                    citizensAndRobots.Add(robot);
                }

                input = Console.ReadLine();
            }

            string fakeIds = Console.ReadLine();

            foreach (var id in citizensAndRobots)
            {
                if (id.IdNumber.EndsWith(fakeIds))
                {
                    Console.WriteLine(id.IdNumber);
                }
            }
        }
    }
}
