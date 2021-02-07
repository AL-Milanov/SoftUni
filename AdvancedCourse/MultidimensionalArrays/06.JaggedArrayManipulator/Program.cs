using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                long[] cols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
                jaggedArray[row] = new double[cols.Length];
                for (int col = 0; col < cols.Length; col++)
                {
                    jaggedArray[row][col] += cols[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                int upperRow = jaggedArray[row].Length;
                int lowerRow = jaggedArray[row + 1].Length;

                if (upperRow == lowerRow)
                {
                    jaggedArray[row] = MultiplyOrDivide("multiply", jaggedArray[row]);
                    jaggedArray[row + 1] = MultiplyOrDivide("multiply", jaggedArray[row + 1]);
                }
                else
                {
                    jaggedArray[row] = MultiplyOrDivide("divide", jaggedArray[row]);
                    jaggedArray[row + 1] = MultiplyOrDivide("divide", jaggedArray[row + 1]);
                }
            }

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string token = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (row < jaggedArray.Length && row >= 0
                    && jaggedArray[row].Length > col && col >= 0)
                {
                    if (token == "add")
                    {
                        jaggedArray[row][col] += value;

                    }
                    else if (token == "subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }
                }

                command = Console.ReadLine().ToLower();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }

        }

        static double[] MultiplyOrDivide(string token, double[] array)
        {
            if (token == "divide")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] /= 2;
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] *= 2;
                }
            }
            return array;
        }
    }
}
