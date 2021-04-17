using System;

namespace _08.CustomThreeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstName = input[0];
            string lastName = input[1];
            string address = input[2];
            string town = input[3]; 

            if (input.Length == 5)
            {
                town += " " + input[4];
            }
            CustomTuple<string, string, string> firstTuple =
                new CustomTuple<string, string, string>(
                    firstName + " " + lastName, address, town);
            Console.WriteLine(firstTuple);

            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = input[0];
            int litersBeer = int.Parse(input[1]);
            bool isAbleToDrink = IsAbleToDrink(input[2]);
            
            CustomTuple<string, int, bool> secondTuple =
                new CustomTuple<string, int, bool>(
                    name, litersBeer, isAbleToDrink);
            Console.WriteLine(secondTuple);

            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            name = input[0];
            double accountBalance = double.Parse(input[1]);
            string bank = input[2];
            if (input.Length == 4)
            {
                bank += " " + input[3];
            }
            CustomTuple<string, double, string> thirdTruple =
                new CustomTuple<string, double, string>(
                    name, accountBalance, bank);

            Console.WriteLine(thirdTruple);

        }
        public static bool IsAbleToDrink(string drink)
        {
            if (drink == "drunk")
            {
                return true;
            }
            return false;
        }
    }
}
