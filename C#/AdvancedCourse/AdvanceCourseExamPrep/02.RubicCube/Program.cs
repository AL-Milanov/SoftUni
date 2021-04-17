using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.RubicCube
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

            int[,] rubicCube = new int[rows, cols];

            int number = 1;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    rubicCube[row, col] = number++;
                }
            }

            int token = int.Parse(Console.ReadLine());

            for (int i = 0; i < token; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int index = int.Parse(command[0]);
                int moves = int.Parse(command[2]);
                string direction = command[1];

                Queue<int> queue = new Queue<int>();
                Queue<int> reversed = new Queue<int>();

                FillingQueue(queue, index, rubicCube, direction);
                queue = Moves(moves, queue, direction);
                
                ShuffleRubicCube(index, queue, rubicCube, direction);

            }
            int cubeParameter = cols * rows;
            number = 1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (rubicCube[row, col] == number)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int[] indexes = FindNumber(rubicCube, number);
                        Console.WriteLine($"Swap ({row}, {col}) with ({indexes[0]}, {indexes[1]})");
                        int currentValue = rubicCube[row, col];
                        rubicCube[row, col] = rubicCube[indexes[0], indexes[1]];
                        rubicCube[indexes[0], indexes[1]] = currentValue;
                    }
                    number++;
                }
            }
        }

        private static int[] FindNumber(int[,] rubicCube, int number)
        {
            int[] indexes = new int[2];
            for (int row = 0; row < rubicCube.GetLength(0); row++)
            {
                for (int col = 0; col < rubicCube.GetLength(1); col++)
                {
                    if (rubicCube[row, col] == number)
                    {
                        indexes[0] = row;
                        indexes[1] = col;
                        return indexes;
                    }
                }
            }
            return indexes;
        }

        private static void ShuffleRubicCube(
            int index, Queue<int> queue, int[,] rubicCube, string direction)
        {
            if (direction == "up" || direction == "down")
            {
                for (int i = 0; i < rubicCube.GetLength(1); i++)
                {
                    rubicCube[i, index] = queue.Dequeue();
                }
            }
            else
            {
                for (int i = 0; i < rubicCube.GetLength(0); i++)
                {
                    rubicCube[index, i] = queue.Dequeue();
                }
            }

        }

        private static Queue<int> Moves(int moves, Queue<int> queue, string direction)
        {
            bool isDownORRight = direction == "down" || direction == "right";

            if (isDownORRight)
            {
                queue = new Queue<int>(queue.Reverse());
            }
            for (int i = 0; i < moves; i++)
            {
                int last = queue.Dequeue();
                queue.Enqueue(last);
            }
            return isDownORRight  ? new Queue<int>(queue.Reverse()) : queue ;
        }

        private static void FillingQueue(
            Queue<int> queue, int index, int[,] rubicCube, string direction)
        {
            if (direction == "up" || direction == "down")
            {
                for (int i = 0; i < rubicCube.GetLength(1); i++)
                {
                    queue.Enqueue(rubicCube[i, index]);
                }
            }
            else
            {
                for (int i = 0; i < rubicCube.GetLength(0); i++)
                {
                    queue.Enqueue(rubicCube[index, i]);
                }
            }
        }
    }
}
