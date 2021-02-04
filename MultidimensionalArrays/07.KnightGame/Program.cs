using System;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());
            string[,] chess = new string[rowsAndCols, rowsAndCols];

            for (int row = 0; row < rowsAndCols; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < rowsAndCols; col++)
                {
                    chess[row, col] = input[col].ToString();
                }
            }

            int removedKnights = 0;

            while (true)
            {
                int currentKnightsInDanger = 0;
                int knightsToAttack = 0;
                int rowOfDangerKnight = -1;
                int colOfDangerKnight = -1;

                for (int row = 0; row < rowsAndCols; row++)
                {
                    for (int col = 0; col < rowsAndCols; col++)
                    {
                        if (chess[row, col] == "K")
                        {

                            if (IsValidIndex(row + 2, col - 1, rowsAndCols) &&
                                    IsKnight(row + 2, col - 1, chess))
                            {
                                knightsToAttack++;
                            }

                            if (IsValidIndex(row + 2, col + 1, rowsAndCols) &&
                                    IsKnight(row + 2, col + 1, chess))
                            {
                                knightsToAttack++;
                            }

                            if (IsValidIndex(row + 1, col - 2, rowsAndCols) &&
                                    IsKnight(row + 1, col - 2, chess))
                            {
                                knightsToAttack++;
                            }

                            if (IsValidIndex(row + 1, col + 2, rowsAndCols) &&
                                    IsKnight(row + 1, col + 2, chess))
                            {
                                knightsToAttack++;
                            }

                            if (IsValidIndex(row - 2, col - 1, rowsAndCols) &&
                                    IsKnight(row - 2, col - 1, chess))
                            {
                                knightsToAttack++;
                            }

                            if (IsValidIndex(row - 2, col + 1, rowsAndCols) &&
                                    IsKnight(row - 2, col + 1, chess))
                            {
                                knightsToAttack++;
                            }

                            if (IsValidIndex(row - 1, col - 2, rowsAndCols) &&
                                    IsKnight(row - 1, col - 2, chess))
                            {
                                knightsToAttack++;
                            }

                            if (IsValidIndex(row - 1, col + 2, rowsAndCols) &&
                                    IsKnight(row - 1, col + 2, chess))
                            {
                                knightsToAttack++;
                            }

                            if (knightsToAttack > currentKnightsInDanger)
                            {
                                currentKnightsInDanger = knightsToAttack;
                                rowOfDangerKnight = row;
                                colOfDangerKnight = col;
                            }

                            knightsToAttack = 0;
                        }

                    }
                }

                if (currentKnightsInDanger == 0)
                {
                    break;
                }

                chess[rowOfDangerKnight, colOfDangerKnight] = "0";
                removedKnights++;

            }

            Console.WriteLine(removedKnights);
        }

        private static bool IsKnight(int row, int col, string[,] chess)
        {
            if (chess[row, col] == "K")
            {
                return true;
            }
            return false;
        }

        private static bool IsValidIndex(int row, int col, int rowsAndCols)
        {
            return row >= 0 && row < rowsAndCols && col >= 0 && col < rowsAndCols;
        }
    }
}
