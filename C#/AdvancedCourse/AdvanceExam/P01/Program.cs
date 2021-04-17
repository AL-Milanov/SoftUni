using System;
using System.Collections.Generic;
using System.Linq;

namespace P01
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[,] matrix = new string[fieldSize, fieldSize];

            Queue<string> attacks = new Queue<string>(Console.ReadLine().Split(",").ToArray());

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            int firstPlayerDestroyed = 0;
            int secondPlayerDestroyed = 0;

            for (int row = 0; row < fieldSize; row++)
            {
                string[] data = Console.ReadLine().Split().ToArray();

                for (int col = 0; col < fieldSize; col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == "<")
                    {
                        firstPlayerShips++;
                    }
                    else if (matrix[row, col] == ">")
                    {
                        secondPlayerShips++;
                    }
                }
            }

            int count = 0;
            while (attacks.Count != 0)
            {
                string[] attackData = attacks.Dequeue().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int rowAttack = int.Parse(attackData[0]);
                int colAttack = int.Parse(attackData[1]);
                int currentFirstDestroyed = 0;
                int currentSecondDestroyed = 0;

                if (IsValidCoordinate(rowAttack, colAttack, fieldSize))
                {
                    if (count % 2 == 0)
                    {
                        if (matrix[rowAttack, colAttack] == ">")
                        {
                            matrix[rowAttack, colAttack] = "X";
                            secondPlayerShips--;
                            firstPlayerDestroyed++;
                        }
                    }
                    else
                    {
                        if (matrix[rowAttack, colAttack] == "<")
                        {
                            matrix[rowAttack, colAttack] = "X";
                            firstPlayerShips--;
                            secondPlayerDestroyed++;
                        }
                    }
                    if (matrix[rowAttack, colAttack] == "#")
                    {
                        currentFirstDestroyed += IsFirstPlayerShip(rowAttack - 1, colAttack - 1, matrix);
                        currentFirstDestroyed += IsFirstPlayerShip(rowAttack - 1, colAttack, matrix);
                        currentFirstDestroyed += IsFirstPlayerShip(rowAttack - 1, colAttack + 1, matrix);
                        currentFirstDestroyed += IsFirstPlayerShip(rowAttack, colAttack - 1, matrix);
                        currentFirstDestroyed += IsFirstPlayerShip(rowAttack, colAttack + 1, matrix);
                        currentFirstDestroyed += IsFirstPlayerShip(rowAttack + 1, colAttack - 1, matrix);
                        currentFirstDestroyed += IsFirstPlayerShip(rowAttack + 1, colAttack, matrix);
                        currentFirstDestroyed += IsFirstPlayerShip(rowAttack + 1, colAttack + 1, matrix);

                        currentSecondDestroyed += IsSecondPlayerShip(rowAttack - 1, colAttack - 1, matrix);
                        currentSecondDestroyed += IsSecondPlayerShip(rowAttack - 1, colAttack, matrix);
                        currentSecondDestroyed += IsSecondPlayerShip(rowAttack - 1, colAttack + 1, matrix);
                        currentSecondDestroyed += IsSecondPlayerShip(rowAttack, colAttack - 1, matrix);
                        currentSecondDestroyed += IsSecondPlayerShip(rowAttack, colAttack + 1, matrix);
                        currentSecondDestroyed += IsSecondPlayerShip(rowAttack + 1, colAttack - 1, matrix);
                        currentSecondDestroyed += IsSecondPlayerShip(rowAttack + 1, colAttack, matrix);
                        currentSecondDestroyed += IsSecondPlayerShip(rowAttack + 1, colAttack + 1, matrix);

                        firstPlayerShips -= currentFirstDestroyed;
                        secondPlayerShips -= currentSecondDestroyed;

                        if (count % 2 == 0)
                        {
                            firstPlayerDestroyed += currentFirstDestroyed + currentSecondDestroyed;
                        }
                        else
                        {
                            secondPlayerDestroyed += currentFirstDestroyed + currentSecondDestroyed;
                        }
                    }
                }

                count++;

                if (secondPlayerShips == 0)
                {
                    Console.WriteLine($"Player One has won the game! {firstPlayerDestroyed} ships have been sunk in the battle.");
                    return;
                }
                else if (firstPlayerShips == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {secondPlayerDestroyed} ships have been sunk in the battle.");
                    return;
                }
            }

            Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
        }

        private static int IsSecondPlayerShip(int row, int col, string[,] matrix)
        {
            if (IsValidCoordinate(row, col, matrix.GetLength(0)))
            {
                if (matrix[row, col] == ">")
                {
                    matrix[row, col] = "X";
                    return 1;
                }
            }

            return 0;
        }

        private static int IsFirstPlayerShip(int row, int col, string[,] matrix)
        {
            if (IsValidCoordinate(row, col, matrix.GetLength(0)))
            {
                if (matrix[row, col] == "<")
                {
                    matrix[row, col] = "X";
                    return 1;
                }
            }

            return 0;
        }

        private static bool IsValidCoordinate(int row, int col, int fieldSize)
        {
            return row >= 0 && row < fieldSize && col >= 0 && col < fieldSize;
        }
    }
}