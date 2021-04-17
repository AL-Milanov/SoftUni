using System;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] bombs = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    bombs[row, col] = data[col];
                }
            }

            string[] cordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cordinates.Length; i++)
            {
                string[] cordArgs = cordinates[i].Split(",", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(cordArgs[0]);
                int col = int.Parse(cordArgs[1]);
                int bombPower = bombs[row, col];

                if (bombPower > 0)
                {
                    BombCell(row, col, bombs, bombPower, n);
                    BombCell(row, col - 1, bombs, bombPower, n);
                    BombCell(row, col + 1, bombs, bombPower, n);
                    BombCell(row - 1, col, bombs, bombPower, n);
                    BombCell(row - 1, col - 1, bombs, bombPower, n);
                    BombCell(row - 1, col + 1, bombs, bombPower, n);
                    BombCell(row + 1, col -1, bombs, bombPower, n);
                    BombCell(row + 1, col, bombs, bombPower, n);
                    BombCell(row + 1, col + 1, bombs, bombPower, n);
                }
            }
            int sum = 0;
            int aliveCells = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (bombs[row,col] > 0)
                    {
                        sum += bombs[row, col];
                        aliveCells++;
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(bombs[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void BombCell(int row, int col, int[,] bombs, int bombPower, int n)
        {
            if (row >= 0 && row < n &&
                col >= 0 && col < n && 
                bombs[row,col] > 0)
            {
                bombs[row, col] -= bombPower;
            }
        }
    }
}

