using System;


namespace _08.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Decode")
            {
                string[] cmdArgs = command.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];

                if (action == "Move")
                {
                    int length = int.Parse(cmdArgs[1]);
                    string line = encryptedMessage.Substring(0, length);
                    encryptedMessage = encryptedMessage.Remove(0, length);
                    encryptedMessage += line;
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string symbol = cmdArgs[2];

                    encryptedMessage = encryptedMessage.Insert(index, symbol);
                }
                else if (action == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    encryptedMessage = encryptedMessage.Replace(substring, replacement);
                }



                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
