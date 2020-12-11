using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePianist
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {

                string[] input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string token = input[0];
                string composer = input[1];
                string key = input[2];

                pieces.Add(token, new List<string> {composer, key });

            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] cmdArgs = command.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                string piece = cmdArgs[1];

                if (action == "Add")
                {
                    string composer = cmdArgs[2];
                    string key = cmdArgs[3];
                    if (pieces.Keys.Contains(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(piece, new List<string> { composer, key });
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    
                }
                else if(action == "Remove")
                {
                    if (pieces.Keys.Contains(piece))
                    {
                        Console.WriteLine($"Successfully removed {piece}!");
                        pieces.Remove(piece);
                    }
                    else
                    {
                        
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (action == "ChangeKey")
                {
                    string newKey = cmdArgs[2];
                    if (pieces.Keys.Contains(piece))
                    {
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        pieces[piece][1] = newKey;
                        
                    }
                    else
                    {

                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }

                }

                command = Console.ReadLine();
            }

            foreach (var piece in pieces.OrderBy(n=> n.Key).ThenBy(c => c.Value[0]))
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}
