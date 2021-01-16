using System;
using System.Linq;

namespace _03.MaximalSum
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

                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }

            }
            int maximalSum = int.MinValue;
            int startRowIndex = 0;
            int startColIndex = 0;
            int endRowIndex = 0;
            int endColIndex = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                int currentSum = 0;
                for (int col = 0; col < cols - 2; col++)
                {
                    currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > maximalSum)
                    {
                        maximalSum = currentSum;
                        startColIndex = col;
                        startRowIndex = row;
                        endColIndex = col + 2;
                        endRowIndex = row + 2;
                    }
                }
            }
            Console.WriteLine($"Sum = {maximalSum}");


            for (int row = startRowIndex; row < endRowIndex + 1; row++)
            {
                for (int col = startColIndex; col < endColIndex + 1; col++)
                {

                    Console.Write(matrix[row, col] + " ");

                }
                Console.WriteLine();
            }

        }
    }
}
