using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            string snake = Console.ReadLine();
            char[,] snakeMoves = new char[rows, cols];
            int rotue = 0;
            Queue<char> currentSnakeChar = new Queue<char>(snake);

            for (int row = 0; row < rows; row++)
            {
                if (rotue % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        snakeMoves[row, col] = currentSnakeChar.Dequeue();
                        if (currentSnakeChar.Count == 0)
                        {
                            currentSnakeChar = new Queue<char>(snake);
                        }
                    }
                    rotue++;
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        snakeMoves[row, col] = currentSnakeChar.Dequeue();
                        if (currentSnakeChar.Count == 0)
                        {
                            currentSnakeChar = new Queue<char>(snake);
                        }
                    }
                    rotue++;
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(snakeMoves[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
