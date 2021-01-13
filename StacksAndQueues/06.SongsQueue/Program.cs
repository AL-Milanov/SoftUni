using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> queue = new Queue<string>(songs);

            string command = Console.ReadLine();

            while (true)
            {
                
                if (command.Contains("Play"))
                {
                    queue.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    command = command.Remove(0, 4);
                    string currentSong = command;

                    if (queue.Contains(currentSong))
                    {
                        Console.WriteLine($"{currentSong} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(currentSong);
                    }
                }
                else if (command.Contains("Show"))
                {
                    Console.WriteLine(String.Join(", ", queue));
                }
                if (queue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
