using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Garden
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

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = 0;
                }
            }

            Dictionary<int, int> flowersCordinates = new Dictionary<int, int>();

            string command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int flowerRow = int.Parse(cmdArgs[0]);
                int flowerCol = int.Parse(cmdArgs[1]);

                if (IsValidCoordinate(flowerRow, flowerCol, rows, cols))
                {
                    matrix[flowerRow, flowerCol] = 1;
                    flowersCordinates.Add(flowerRow, flowerCol);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                command = Console.ReadLine();
            }

            foreach (var item in flowersCordinates)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[item.Key, col] += 1;
                }
                for (int row = 0; row < rows; row++)
                {
                    matrix[row, item.Value] += 1;
                }
                matrix[item.Key, item.Value] -= 2;
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidCoordinate(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}
