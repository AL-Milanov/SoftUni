using System;
using System.Collections.Generic;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> command = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));
            string[,] field = new string[n, n];
            int rowIndex = -1;
            int colIndex = -1;
            int allCoal = 0;

            for (int row = 0; row < n; row++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = data[col];

                    if (field[row, col] == "s")
                    {
                        rowIndex = row;
                        colIndex = col;
                    }
                    else if (field[row, col] == "c")
                    {
                        allCoal++;
                    }
                }
            }

            int totalCoalCollected = 0;

            while (command.Count != 0)
            {
                string currentCommand = command.Dequeue();
                bool isEnd = false;

                if (currentCommand == "up")
                {
                    if (InField(rowIndex - 1, colIndex, n))
                    {
                        if (field[rowIndex - 1, colIndex] == "e")
                        {
                            isEnd = true;
                        }
                        else if (field[rowIndex - 1, colIndex] == "c")
                        {
                            totalCoalCollected++;
                        }
                        field[rowIndex, colIndex] = "*";
                        field[rowIndex - 1, colIndex] = "s";
                    }

                }
                else if (currentCommand == "down")
                {
                    if (InField(rowIndex + 1, colIndex, n))
                    {
                        if (field[rowIndex + 1, colIndex] == "e")
                        {
                            isEnd = true;
                        }
                        else if (field[rowIndex + 1, colIndex] == "c")
                        {
                            totalCoalCollected++;
                        }
                        field[rowIndex, colIndex] = "*";
                        field[rowIndex + 1, colIndex] = "s";
                    }
                }
                else if (currentCommand == "left")
                {
                    if (InField(rowIndex, colIndex - 1, n))
                    {
                        if (field[rowIndex, colIndex - 1] == "e")
                        {
                            isEnd = true;
                        }
                        else if (field[rowIndex, colIndex - 1] == "c")
                        {
                            totalCoalCollected++;
                        }
                        field[rowIndex, colIndex] = "*";
                        field[rowIndex, colIndex - 1] = "s";
                    }
                }
                else if (currentCommand == "right")
                {
                    if (InField(rowIndex, colIndex + 1, n))
                    {
                        if (field[rowIndex, colIndex + 1] == "e")
                        {
                            isEnd = true;
                        }
                        else if (field[rowIndex, colIndex + 1] == "c")
                        {
                            totalCoalCollected++;
                        }
                        field[rowIndex, colIndex] = "*";
                        field[rowIndex, colIndex + 1] = "s";
                    }
                }

                bool isFound = false;
                for (int row = 0; row < field.GetLength(0); row++)
                {
                    for (int col = 0; col < field.GetLength(1); col++)
                    {
                        if (field[row, col] == "s")
                        {
                            isFound = true;
                            rowIndex = row;
                            colIndex = col;
                            break;
                        }
                    }
                    if (isFound)
                    {
                        break;
                    }
                }
                if (isEnd == true)
                {
                    Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                    return;
                }
                else if (allCoal == totalCoalCollected)
                {
                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                    return;
                }
            }
            Console.WriteLine($"{allCoal - totalCoalCollected} coals left. ({rowIndex}, {colIndex})");
        }

        private static bool InField(int rowIndex, int colIndex, int n)
        {
            return rowIndex >= 0 && rowIndex < n && colIndex >= 0 && colIndex < n;

        }

    }
}
