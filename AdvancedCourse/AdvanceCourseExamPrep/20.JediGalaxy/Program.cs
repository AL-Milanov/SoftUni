using System;
using System.Linq;

namespace _20.JediGalaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] matrix = new int[rows, cols];

            int value = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value;
                    value++;
                }
            }

            string command = Console.ReadLine();
            long ivoSum = 0L;

            while (command != "Let the Force be with you")
            {
                int[] ivoData = command.Split()
                    .Select(int.Parse)
                    .ToArray();
                int ivoRow = ivoData[0];
                int ivoCol = ivoData[1];

                command = Console.ReadLine();

                int[] evilData = command.Split()
                    .Select(int.Parse)
                    .ToArray();
                int evilRow = evilData[0];
                int evilCol = evilData[1];

                for (int row = evilRow ; row >= 0; row--)
                {
                    if (IsValidCoordinate(row, evilCol, rows, cols))
                    {
                        matrix[row, evilCol] = 0;
                    }
                    evilCol--;
                }

                for (int row = ivoRow; row >= 0; row--)
                {
                    if (IsValidCoordinate(row, ivoCol, rows, cols))
                    {
                        ivoSum += matrix[row, ivoCol];
                    }

                    ivoCol++;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(ivoSum);
        }

        private static bool IsValidCoordinate(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}
