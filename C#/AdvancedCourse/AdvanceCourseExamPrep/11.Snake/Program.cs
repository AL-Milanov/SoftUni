using System;

namespace _11.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int snakeRow = -1;
            int snakeCol = -1;

            int firstBurrowRow = -1;
            int firstBurrowCol = -1;

            int secondBurrowRow = -1;
            int secondBurrowCol = -1;

            int count = 0;
            for (int row = 0; row < n; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = data[col];

                    if (data[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    else if (data[col] == 'B')
                    {
                        if (count == 0)
                        {
                            firstBurrowRow = row;
                            firstBurrowCol = col;
                            count++;
                        }
                        else
                        {
                            secondBurrowRow = row;
                            secondBurrowCol = col;
                        }
                    }
                }
            }

            int foodEaten = 0;

            string command = Console.ReadLine();

            while (foodEaten < 10)
            {
                matrix[snakeRow, snakeCol] = '.';
                snakeRow = IsValidRow(snakeRow, command);
                snakeCol = IsValidCol(snakeCol, command);

                if (IsValidIndex(snakeRow, snakeCol, n) == false)
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {foodEaten}");
                    Print(matrix);
                    return;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodEaten++;
                    if (foodEaten >= 10)
                    {
                        matrix[snakeRow, snakeCol] = 'S';
                        break;
                    }
                }
                else if (matrix[snakeRow, snakeCol] == 'B')
                {
                    if (snakeRow == firstBurrowRow && snakeCol == firstBurrowCol)
                    {
                        snakeRow = secondBurrowRow;
                        snakeCol = secondBurrowCol;
                        matrix[firstBurrowRow, firstBurrowCol] = '.';
                    }
                    else if (snakeRow == secondBurrowRow && snakeCol == secondBurrowCol)
                    {
                        snakeRow = firstBurrowRow;
                        snakeCol = firstBurrowCol;
                        matrix[secondBurrowRow, secondBurrowCol] = '.';
                    }
                }

                matrix[snakeRow, snakeCol] = 'S';

                command = Console.ReadLine();
            }

            Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {foodEaten}");

            Print(matrix);
        }

        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static int IsValidCol(int col, string command)
        {
            if (command == "left")
            {
                return col - 1;
            }
            else if (command == "right")
            {
                return col + 1;
            }

            return col;
        }

        private static int IsValidRow(int row, string command)
        {
            if (command == "up")
            {
                return row - 1;
            }
            else if (command == "down")
            {
                return row + 1;
            }

            return row;
        }

        private static bool IsValidIndex(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
