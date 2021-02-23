using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        
        {
            Knight darkKnight = new BladeKnight("Berav", 60);
            Wizard darkWizard = new SoulMaster("Regalia", 80);
            MuseElf hero = new MuseElf("Asmon", 120);
            Console.WriteLine(hero);
            Console.WriteLine(darkWizard);
            Console.WriteLine(darkKnight);
        }
    }
}