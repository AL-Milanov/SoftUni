using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IHaveBirthday> haveBirthdays = new List<IHaveBirthday>();
            while (input != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string nameOrModel = data[1];
                
                if (data[0] == "Citizen")
                {
                    int age = int.Parse(data[2]);
                    long id = long.Parse(data[3]);
                    string birthDate = data[4];
                    Citizen citizen = new Citizen(nameOrModel, age, id, birthDate);
                    haveBirthdays.Add(citizen);
                }
                else if(data[0] == "Pet")
                {
                    string name = data[1];
                    string birthDate = data[2];
                    Pet pet = new Pet(name, birthDate);
                    haveBirthdays.Add(pet);
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var date in haveBirthdays)
            {
                if (date.BirthDate.EndsWith(year))
                {
                    Console.WriteLine(date.BirthDate);
                }
            }
        }
    }
}
