using System;

namespace _21.DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {

            string[,] matrix = new string[8, 8];

            for (int row = 0; row < 8; row++)
            {
                string[] input = Console.ReadLine().Split(",");

                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = input[col];

                }

            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] cmdArgs = command.Split("-");

                string figure = cmdArgs[0][0].ToString();
                int figureRow = int.Parse(cmdArgs[0][1].ToString());
                int figureCol = int.Parse(cmdArgs[0][2].ToString());

                int nextRow = int.Parse(cmdArgs[1][0].ToString());
                int nextCol = int.Parse(cmdArgs[1][1].ToString());

                if (matrix[figureRow, figureCol] != figure)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                if (!IsOutOfTheBoard(nextRow, nextCol))
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }


                bool canMove = CanMove(figure, figureRow, figureCol, nextRow, nextCol);

                if (canMove == false)
                {
                    Console.WriteLine("Invalid move!");
                }
                else
                {
                    matrix[nextRow, nextCol] = figure;
                    matrix[figureRow, figureCol] = "x";
                }
            }
        }

        private static bool IsOutOfTheBoard(int nextRow, int nextCol)
        {
            return nextRow >= 0 && nextRow < 8 && nextCol >= 0 && nextCol < 8;
        }

        private static bool CanMove(string figure, int figureRow, int figureCol, int nextRow, int nextCol)
        {
            bool isAbleToMove = false;

            if (figure == "P")
            {
                if (figureRow - 1 == nextRow)
                {
                    isAbleToMove = true;
                }
            }
            else if (figure == "R")
            {
                isAbleToMove = CanMoveVerticalAndHorizional(figureRow, nextRow, figureCol, nextCol);
                
            }
            else if (figure == "B")
            {

                if (figureRow == nextRow || figureCol == nextCol)
                {
                    return false;
                }

                isAbleToMove = CanMoveDiagonal(figureRow, nextRow, figureCol, nextCol);
                
            }
            else if (figure == "K")
            {
                if (figureRow -1 == nextRow && figureCol + 1 == nextCol)
                {
                    isAbleToMove = true;
                }
                else if (figureRow == nextRow && figureCol + 1 == nextCol)
                {
                    isAbleToMove = true;
                }
                else if (figureRow + 1 == nextRow && figureCol + 1 == nextCol)
                {
                    isAbleToMove = true;
                }
                else if (figureRow - 1 == nextRow && figureCol == nextCol)
                {
                    isAbleToMove = true;
                }
                else if (figureRow + 1 == nextRow && figureCol == nextCol)
                {
                    isAbleToMove = true;
                }
                else if (figureRow - 1 == nextRow && figureCol - 1 == nextCol)
                {
                    isAbleToMove = true;
                }
                else if (figureRow == nextRow && figureCol - 1 == nextCol)
                {
                    isAbleToMove = true;
                }
                else if (figureRow + 1 == nextRow && figureCol - 1 == nextCol)
                {
                    isAbleToMove = true;
                }
            }
            else if (figure == "Q")
            {
                bool queenVerticalAndHorizonal = CanMoveVerticalAndHorizional(figureRow, nextRow, figureCol, nextCol);

                bool queenDiagonal = CanMoveDiagonal(figureRow, nextRow, figureCol, nextCol);

                if (queenDiagonal || queenVerticalAndHorizonal)
                {
                    isAbleToMove = true;
                }
            }

            if (isAbleToMove == false)
            {
                return false;
            }

            return true;
        }

        private static bool CanMoveDiagonal(int figureRow, int nextRow, int figureCol, int nextCol)
        {
            bool canMoveDiagonal = false;

            for (int i = 1; i <= 8; i++)
            {
                if (figureRow - i == nextRow && figureCol - i == nextCol)
                {
                    canMoveDiagonal = true;
                }
                else if (figureRow - i == nextRow && figureCol + i == nextCol)
                {
                    canMoveDiagonal = true;
                }
                else if (figureRow + i == nextRow && figureCol - i == nextCol)
                {
                    canMoveDiagonal = true;
                }
                else if (figureRow + i == nextRow && figureCol + i == nextCol)
                {
                    canMoveDiagonal = true;
                }

                if (canMoveDiagonal)
                {
                    break;
                }

            }

            return canMoveDiagonal;
        }

        private static bool CanMoveVerticalAndHorizional(int figureRow, int nextRow, int figureCol, int nextCol)
        {
            if (figureRow == nextRow)
            {
                return true;
            }
            if (figureCol == nextCol)
            {
                return true;
            }

            return false;
        }
    }
}
