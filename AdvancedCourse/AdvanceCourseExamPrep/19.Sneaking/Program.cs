using System;

namespace _19.Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];

            int samRow = -1;
            int samCol = -1;
            int nikoladzeRow = -1;
            int nikoladzeCol = -1;

            for (int row = 0; row < rows; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();
                matrix[row] = new char[data.Length];
                for (int col = 0; col < data.Length; col++)
                {
                    char currChar = data[col];
                    matrix[row][col] = currChar;
                    if (matrix[row][col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                    }
                    else if (matrix[row][col] == 'N')
                    {
                        nikoladzeRow = row;
                        nikoladzeCol = col;
                    }
                }
            }

            char[] command = Console.ReadLine().ToCharArray();

            for (int i = 0; i < command.Length; i++)
            {
                MoveGuards(matrix);
                char token = command[i];

                if (IsSamHere(matrix))
                {
                    matrix[samRow][samCol] = 'X';
                    Console.WriteLine($"Sam died at {samRow}, {samCol}");
                    break;
                }

                matrix[samRow][samCol] = '.';

                samRow = MoveSamRow(samRow, samCol, token);
                samCol = MoveSamCol(samRow, samCol, token);

                matrix[samRow][samCol] = 'S';

                if (nikoladzeRow == samRow)
                {
                    matrix[nikoladzeRow][nikoladzeCol] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsSamHere(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        int currentCol = col;

                        for (int i = currentCol; i < matrix[row].Length; i++)
                        {
                            if (matrix[row][i] == 'S')
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private static int MoveSamCol(int row, int col, char token)
        {
            if (token == 'L')
            {
                return col - 1;
            }
            else if (token == 'R')
            {
                return col + 1;
            }

            return col;
        }

        private static int MoveSamRow(int row, int col, char token)
        {
            if (token == 'U')
            {
                return row - 1;
            }
            else if (token == 'D')
            {
                return row + 1;
            }

            return row;
        }

        private static void MoveGuards(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        int nextCol = col + 1;
                        matrix[row][col] = '.';

                        if (IsValidIndex(row, nextCol, matrix.Length, matrix[row].Length))
                        {
                            matrix[row][nextCol] = 'b';
                        }
                        else
                        {
                            matrix[row][col] = 'd';

                        }
                        break;
                    }
                    else if (matrix[row][col] == 'd')
                    {
                        int nextCol = col - 1;
                        matrix[row][col] = '.';

                        if (IsValidIndex(row, nextCol, matrix.Length, matrix[row].Length))
                        {
                            matrix[row][nextCol] = 'd';
                        }
                        else
                        {
                            matrix[row][col] = 'b';

                        }
                        break;
                    }
                }
            }
        }
        private static bool IsValidIndex(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}
