using System;

namespace _14.ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < n; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = data[col];

                    if (data[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            bool isWon = false;

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';
                int lastPlayerRow = playerRow;
                int lastPlayerCol = playerCol;
                playerRow = NextRow(playerRow, n, command);
                playerCol = NextCol(playerCol, n, command);

                if (matrix[playerRow, playerCol] == 'T')
                {
                    playerRow = lastPlayerRow;
                    playerCol = lastPlayerCol;
                }
                else if (matrix[playerRow, playerCol] == 'B')
                {
                    playerRow = NextRow(playerRow, n, command);
                    playerCol = NextCol(playerCol, n, command);
                }

                if (matrix[playerRow, playerCol] == 'F')
                {
                    isWon = true;
                }

                matrix[playerRow, playerCol] = 'f';

                if (isWon)
                {
                    break;
                }
            }
            
            string result = isWon ? "Player won!" : "Player lost!";
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

        private static int NextCol(int col, int n, string command)
        {
            if (command == "left")
            {
                col--;

                if (col < 0)
                {
                    return n - 1;
                }
            }
            else if (command == "right")
            {
                col++;
                if (col == n)
                {
                    return 0;
                }
            }
            return col;
        }

        private static int NextRow(int row, int n, string command)
        {
            if (command == "up")
            {
                row--;
                if (row < 0)
                {
                    return n - 1;
                }
            }
            else if (command == "down")
            {
                row++;
                if (row == n)
                {
                    return 0;
                }
            }
            return row;
        }
    }
}
