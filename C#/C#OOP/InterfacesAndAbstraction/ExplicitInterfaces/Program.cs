using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string data = Console.ReadLine();

                if (data == "End")
                {
                    break;
                }

                string[] dataSplited = data.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = dataSplited[0];
                string country = dataSplited[1];
                int age = int.Parse(dataSplited[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                person.GetName();
                IResident resident = citizen;
                resident.GetName();

            }
        }
    }
}
