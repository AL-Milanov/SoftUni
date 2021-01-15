using System;
using System.Linq;

namespace _02._2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[rowsAndCols[0], rowsAndCols[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }

            }

            int squaresOfEquals = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {

                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    string currentChar = matrix[row, col];
                    string nextChar = matrix[row, col + 1];
                    if (currentChar == nextChar)
                    {
                        string bottomLeftChar = matrix[row + 1, col];
                        string bottomRightChar = matrix[row + 1, col + 1];
                        bool isSquareOfEquals = currentChar == bottomLeftChar && 
                            nextChar == bottomRightChar;

                        if (isSquareOfEquals)
                        {
                            squaresOfEquals++;
                        }
                    }
                }
            }

            Console.WriteLine(squaresOfEquals);

        }
    }
}
