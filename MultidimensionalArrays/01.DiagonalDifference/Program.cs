using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }

            }
            int leftSum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (col == row)
                    {
                        leftSum += matrix[row, col];

                    }
                }
            }

            int rightSum = 0;
            int lastIndex = n - 1;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < 1; col++)
                {
                    rightSum += matrix[row, lastIndex];
                    lastIndex--;

                }
            }
            if (rightSum >= leftSum)
            {
                Console.WriteLine(rightSum - leftSum);
            }
            else
            {
                Console.WriteLine(leftSum - rightSum);
            }
        }
    }
}
