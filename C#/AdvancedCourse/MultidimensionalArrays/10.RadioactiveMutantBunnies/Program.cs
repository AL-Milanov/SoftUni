using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = rowsAndCols[0];
            int m = rowsAndCols[1];
            int playerRow = -1;
            int playerCol = -1;

            char[,] field = new char[n, m];

            for (int row = 0; row < n; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();
                for (int col = 0; col < m; col++)
                {
                    field[row, col] = data[col];
                    if (field[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();
            bool isWon = false;
            bool isDead = false;

            foreach (var command in commands)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                if (command == 'U')
                {
                    newPlayerRow--;
                }
                else if (command == 'D')
                {
                    newPlayerRow++;
                }
                else if (command == 'L')
                {
                    newPlayerCol--;
                }
                else if (command == 'R')
                {
                    newPlayerCol++;
                }
                
                if (ValidPosition(newPlayerRow, newPlayerCol, n, m) == false)
                {
                    isWon = true;
                    //?
                    field[playerRow, playerCol] = '.'; 
                }
                else if (field[newPlayerRow, newPlayerCol] == '.')
                {
                    field[playerRow, playerCol] = '.';
                    field[newPlayerRow, newPlayerCol] = 'P';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }
                else if (field[newPlayerRow, newPlayerCol] == 'B')
                {
                    isDead = true;
                    field[playerRow, playerCol] = '.';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }

                List<int[]> bunnies = BunniesCordinates(field);
                SpreadBunnies(bunnies, field);

                if (isWon == false && field[newPlayerRow, newPlayerCol] == 'B')
                {
                    isDead = true;
                }

                if (isDead || isWon)
                {
                    break;
                }

            }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }

            if (isWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else if (isDead)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }        }

        private static void SpreadBunnies(List<int[]> bunnies, char[,] field)
        {
            foreach (var bunny in bunnies)
            {
                int bunnyRow = bunny[0];
                int bunnyCol = bunny[1];
                ValidBunnyPosition(bunnyRow -1, bunnyCol, field);
                ValidBunnyPosition(bunnyRow + 1, bunnyCol, field);
                ValidBunnyPosition(bunnyRow, bunnyCol - 1, field);
                ValidBunnyPosition(bunnyRow, bunnyCol + 1, field);
            }
        }

        private static void ValidBunnyPosition(int row, int col, char[,] field)
        {
            if (ValidPosition(row, col, field.GetLength(0), field.GetLength(1)))
            {
                field[row, col] = 'B';
            }
        }

        private static List<int[]> BunniesCordinates(char[,] field)
        {
            List<int[]> listOfBunnyCords = new List<int[]>();
            
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'B')
                    {
                        listOfBunnyCords.Add(new int[] { row, col });
                    }
                }
            }

            return listOfBunnyCords;

        }

        private static bool ValidPosition(int row, int col, int n, int m)
        {
            return row >= 0 && row < n && col >= 0 && col < m;
        }
    }
}
