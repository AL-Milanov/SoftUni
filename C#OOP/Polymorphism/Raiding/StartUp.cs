using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (raidGroup.Count != n)
            {
                BaseHero newHero = null;
                string name = Console.ReadLine();
                string heroClass = Console.ReadLine();

                if (heroClass == "Druid")
                {
                    newHero = new Druid(name);
                }
                else if (heroClass == "Paladin")
                {
                    newHero = new Paladin(name);
                }
                else if (heroClass == "Rogue")
                {
                    newHero = new Rogue(name);
                }
                else if (heroClass == "Warrior")
                {
                    newHero = new Warrior(name);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                raidGroup.Add(newHero);
            }

            int bossPower = int.Parse(Console.ReadLine());
            string result = raidGroup.Sum(p => p.Power) >= bossPower
                ? "Victory!"
                : "Defeat...";

            raidGroup.ForEach(x => Console.WriteLine(x.CastAbility()));
            Console.WriteLine(result);
        }
    }
}
