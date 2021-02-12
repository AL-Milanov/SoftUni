using System;

namespace _04.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int myRow = -1;
            int myCol = -1;

            int counter = 0;

            int firstPillarRow = -1;
            int firstPillarCol = -1;

            int secondPillarRow = -1;
            int secondPillarCol = -1;

            for (int row = 0; row < n; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < data.Length; col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == 'S')
                    {
                        myRow = row;
                        myCol = col;
                    }
                    else if (matrix[row, col] == 'O')
                    {
                        if (counter == 0)
                        {
                            firstPillarRow = row;
                            firstPillarCol = col;
                            counter++;
                        }
                        else
                        {
                            secondPillarRow = row;
                            secondPillarCol = col;
                        }
                    }
                }
            }

            int moneyEarned = 0;

            while (true)
            {
                string direction = Console.ReadLine();

                matrix[myRow, myCol] = '-';

                myRow = NewRow(direction, myRow, n);
                myCol = NewCol(direction, myCol, n);

                if (IsValid(myRow, myCol, n))
                {
                    if (char.IsDigit(matrix[myRow, myCol]))
                    {
                        moneyEarned += int.Parse(matrix[myRow, myCol].ToString());
                    }
                    else if (matrix[myRow, myCol] == 'O')
                    {
                        if (myRow == firstPillarRow && myCol == firstPillarCol)
                        {
                            myRow = secondPillarRow;
                            myCol = secondPillarCol;
                        }
                        else if (myRow == secondPillarRow && myCol == secondPillarCol)
                        {
                            myRow = firstPillarRow;
                            myCol = firstPillarCol;
                        }
                        matrix[firstPillarRow, firstPillarCol] = '-';
                        matrix[secondPillarRow, secondPillarCol] = '-';
                    }

                    matrix[myRow, myCol] = 'S';
                }

                if (!IsValid(myRow, myCol, n) || moneyEarned >= 50)// ? money
                {
                    break;
                }
            }

            if (moneyEarned >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            Console.WriteLine($"Money: {moneyEarned}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsValid(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        private static int NewCol(string direction, int col, int n)
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

        private static int NewRow(string direction, int row, int n)
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
