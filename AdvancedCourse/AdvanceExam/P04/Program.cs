using System;

namespace P04
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];

            int marioRow = -1;
            int marioCol = -1;

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                matrix[row] = new char[currentRow.Length];
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row][col] = currentRow[col];

                    if (matrix[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }


            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string movement = command[0];
                int enemyRow = int.Parse(command[1]);
                int enemyCol = int.Parse(command[2]);

                matrix[enemyRow][enemyCol] = 'B';
                marioLives--;

                int lastRow = marioRow;
                int lastCol = marioCol;

                matrix[marioRow][marioCol] = '-';
                marioRow = MoveRow(marioRow, movement);
                marioCol = MoveCol(marioCol, movement);

                if (IsValidCoordinates(marioRow, marioCol, rows))
                {
                    if (matrix[marioRow][marioCol] == 'B')
                    {
                        marioLives -= 2;
                    }
                    else if (matrix[marioRow][marioCol] == 'P')
                    {
                        matrix[marioRow][marioCol] = '-';
                        Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
                        break;
                    }
                    if (marioLives <= 0)
                    {
                        matrix[marioRow][marioCol] = 'X';
                        Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                        break;
                    }
                    matrix[marioRow][marioCol] = 'M';
                }
                else
                {
                    marioRow = lastRow;
                    marioCol = lastCol;

                    if (marioLives <= 0)
                    {
                        matrix[marioRow][marioCol] = 'X';
                        Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                        break;
                    }
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }


        private static bool IsValidCoordinates(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        public static int MoveRow(int row, string movement)
        {
            if (movement == "W")
            {
                return row - 1;
            }
            if (movement == "S")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "A")
            {
                return col - 1;
            }
            if (movement == "D")
            {
                return col + 1;
            }

            return col;
        }
    }
}
