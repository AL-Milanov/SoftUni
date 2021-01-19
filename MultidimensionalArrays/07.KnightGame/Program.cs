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

            int knightsHit = 0;
            
            for (int row = 0; row < rowsAndCols; row++)
            {
                for (int col = 0; col < rowsAndCols; col++)
                {
                    if (chess[row, col] == "K")
                    {
                        if (row == 0 && col == 0)
                        {
                            if (chess[row + 2, col + 1] == "K")
                            {
                                chess[row + 2, col + 1] = "0";
                                knightsHit++;
                            }
                            else if (chess[row + 1, col + 2] == "K")
                            {
                                chess[row + 1, col + 2] = "0";
                                knightsHit++;
                            }
                        }
                        else if (row == 0 && col == rowsAndCols - 1)
                        {
                            if (chess[row + 2, col - 2] == "K")
                            {
                                chess[row + 2, col - 2] = "0";
                                knightsHit++;
                            }
                            else if (chess[row + 1, col - 3] == "K")
                            {
                                chess[row + 1, col - 3] = "0";
                                knightsHit++;
                            }
                        }
                        else if (row == rowsAndCols - 1 && col == 0)
                        {
                            if (chess[row - 2, col + 1] == "K")
                            {
                                chess[row - 2, col + 1] = "0";
                                knightsHit++;
                            }
                            else if(chess[row - 1, col + 2] == "K")
                            {
                                chess[row - 1, col + 2] = "0";
                                knightsHit++;
                            }
                        }
                        else if (row == rowsAndCols - 1 && col == rowsAndCols - 1)
                        {
                            if (chess[row - 2, col - 1] == "K")
                            {
                                chess[row - 2, col - 1] = "0";
                                knightsHit++;
                            }
                            else if (chess[row - 1, col - 2] == "K")
                            {
                                chess[row - 1, col - 2] = "0";
                                knightsHit++;
                            }
                        }
                        else if (true)
                        {

                        }
                    }
                }
            }
        }
    }
}
