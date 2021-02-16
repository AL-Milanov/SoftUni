using System;

namespace _17.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int beeRow = -1;
            int beeCol = -1;

            for (int row = 0; row < n; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = data[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string direction = Console.ReadLine();
            int flowers = 0;

            while (direction != "End")
            {
                matrix[beeRow, beeCol] = '.';

                beeRow = NextRow(beeRow, direction);
                beeCol = NextCol(beeCol, direction);

                if (IsValidCoordinates(beeRow, beeCol, n))
                {
                    if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        beeRow = NextRow(beeRow, direction);
                        beeCol = NextCol(beeCol, direction);
                    }
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        flowers++;
                    }
                }
                else 
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                matrix[beeRow, beeCol] = 'B';
                direction = Console.ReadLine();
            }

            string result = flowers >= 5
                ? $"Great job, the bee managed to pollinate {flowers} flowers!"
                : $"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more";
            Console.WriteLine(result);

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidCoordinates(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        private static int NextCol(int col, string direction)
        {
            if (direction == "left")
            {
                return col - 1;
            }
            else if (direction == "right")
            {
                return col + 1;
            }

            return col;
        }

        private static int NextRow(int row, string direction)
        {

            if (direction == "up")
            {
                return row - 1;
            }
            else if (direction == "down")
            {
                return row + 1;
            }

            return row;
        }
    }
}
