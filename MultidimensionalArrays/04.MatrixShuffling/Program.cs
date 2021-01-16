using System;
using System.Linq;

namespace _04.MatrixShuffling
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
            string[,] data = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < cols; col++)
                {
                    data[row, col] = input[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] cmdArgs = command.Split();
                string token = cmdArgs[0];
                int length = cmdArgs.Length;
                if (isValidCordinate(token, length))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int firstRow = int.Parse(cmdArgs[1]);
                    int secondRow = int.Parse(cmdArgs[3]);
                    int firstCol = int.Parse(cmdArgs[2]);
                    int secondCol = int.Parse(cmdArgs[4]);

                    if (isValidRowsAndCols(rows,firstRow, secondRow,
                        cols,firstCol,secondCol))
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string firstElement = data[firstRow, firstCol];
                        string secondElement = data[secondRow, secondCol];
                        data[firstRow, firstCol] = secondElement;
                        data[secondRow, secondCol] = firstElement;
                        Matrix(data);
                    }
                }


                command = Console.ReadLine();
            }
        }

        static bool isValidCordinate(string token, int lenght)
        {
            return token != "swap" || lenght != 5;
        }
        static bool isValidRowsAndCols(int rows, int firstNumRows, int secondNumRows,
            int cols, int firstNumCols, int secondNumCols)
        {
            return rows < firstNumRows || rows < secondNumRows
                || cols < firstNumCols || cols < secondNumCols;
        }
        static void Matrix(string[,] data)
        {
            for (int row = 0; row < data.GetLength(0); row++)
            {
                for (int col = 0; col < data.GetLength(1); col++)
                {
                    Console.Write(data[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
