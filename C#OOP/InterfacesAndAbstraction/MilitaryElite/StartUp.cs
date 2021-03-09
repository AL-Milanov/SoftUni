using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Soldier> army = new List<Soldier>();
            Stack<Private> privates = new Stack<Private>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] soldierData = input.Split();
                string type = soldierData[0];
                int id = int.Parse(soldierData[1]);
                string firstName = soldierData[2];
                string lastName = soldierData[3];

                Soldier soldier = null;

                if (type == nameof(Spy))
                {
                    soldier = new Spy(id, firstName, lastName, int.Parse(soldierData[4]));
                    continue;
                }

                decimal salary = decimal.Parse(soldierData[4]);
                if (type == nameof(Private))
                {
                    soldier = new Private(id, firstName, lastName, salary);
                    privates.Push((Private)soldier);
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                }
                else if (type == nameof(Engineer))
                {
                    Dictionary<string, int> repairs = new Dictionary<string, int>();

                    for (int i = 6; i < soldierData.Length; i += 2)
                    {
                        string part = soldierData[i];
                        int hoursWorked = int.Parse(soldierData[i + 1]);
                        repairs.Add(part, hoursWorked);
                    }
                    try
                    {
                        soldier = new Engineer(id, firstName, lastName, salary, soldierData[5], repairs);
                    }
                    catch { continue; }
                }
                else if (type == nameof(Commando))
                {
                    Dictionary<string, string> missions = new Dictionary<string, string>();
                    for (int i = 6; i < soldierData.Length; i += 2)
                    {
                        string part = soldierData[i];
                        string status = soldierData[i + 1];
                        missions.Add(part, status);
                    }
                    try
                    {
                        soldier = new Commando(id, firstName, lastName, salary, soldierData[5], missions);
                    }
                    catch { continue; }
                }

                army.Add(soldier);
            }

            foreach (var item in army)
            {
                Console.WriteLine(item);
            }
        }

    }
}
