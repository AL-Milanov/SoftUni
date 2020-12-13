using System;

namespace _03.Third
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Finish")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string token = cmdArgs[0];

                if (token == "Replace")
                {
                    string currentChar = cmdArgs[1];
                    string newChar = cmdArgs[2];
                    message = message.Replace(currentChar, newChar);
                    Console.WriteLine(message);
                }
                else if (token == "Cut")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    bool isValidIndex = startIndex >= 0 && endIndex < message.Length;

                    if (isValidIndex)
                    {
                        int count = endIndex - startIndex + 1;
                        message = message.Remove(startIndex, count);
                        Console.WriteLine(message);
                        //
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }
                else if (token == "Make")
                {
                    string upLow = cmdArgs[1];

                    if (upLow == "Upper")
                    {
                        message = message.ToUpper();
                        Console.WriteLine(message);
                    }
                    else if (upLow == "Lower")
                    {
                        message = message.ToLower();
                        Console.WriteLine(message);
                    }
                }
                else if (token == "Check")
                {
                    string substring = cmdArgs[1];

                    if (message.Contains(substring))
                    {
                        Console.WriteLine($"Message contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {substring}");
                    }

                }
                else if (token == "Sum")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    bool isValidIndex = startIndex >= 0 && endIndex < message.Length;

                    if (isValidIndex)
                    {
                        int length = endIndex - startIndex + 1;
                        string substring = message.Substring(startIndex, length);
                        int sum = 0;
                        for (int i = 0; i < substring.Length; i++)
                        {
                            sum += substring[i];

                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }

                }
                command = Console.ReadLine();
            }
        }
    }
}
