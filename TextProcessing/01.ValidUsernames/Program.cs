using System;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            bool isLegit = false;

            foreach (var user in usernames)
            {
                foreach (var item in user)
                {
                    if (char.IsLetterOrDigit(item))
                    {
                        isLegit = true;
                    }
                    else if (item == '-' || item == '_')
                    {
                        isLegit = true;
                    }
                    else
                    {
                        isLegit = false;
                        break;
                    }
                }

                if (user.Length >= 3 && user.Length <= 16 && isLegit)
                {
                    Console.WriteLine(user);
                }
            }
        }
    }
}
