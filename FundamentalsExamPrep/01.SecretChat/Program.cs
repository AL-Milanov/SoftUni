using System;
using System.Linq;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretMessage = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                string[] cmdArgs = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(cmdArgs[1]);
                    secretMessage = secretMessage.Insert(index, " ");
                    Console.WriteLine(secretMessage);
                }
                else if (command == "Reverse")
                {
                    string substring = cmdArgs[1];

                    if (secretMessage.Contains(substring))
                    {
                        int startIndex = secretMessage.IndexOf(substring);
                        secretMessage = secretMessage.Remove(startIndex, substring.Length);
                        string reversedSubstring = string.Empty;
                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reversedSubstring += substring[i];
                        }
                        secretMessage += reversedSubstring;
                        Console.WriteLine(secretMessage);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    secretMessage = secretMessage.Replace(substring, replacement);
                    Console.WriteLine(secretMessage);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {secretMessage}");
        }
    }
}
