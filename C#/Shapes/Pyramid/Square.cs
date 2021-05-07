using System;

namespace Shapes
{
    public class Square : Shape
    {
        private int side;

        public Square(params int[] side)
            : base(side)
        {
            Side = side[0];
        }

        public int Side { get => side; private set => side = value; }

        public override void Draw()
        {
            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    if (i != 0 && i != side - 1)
                    {
                        if (j == 0 || j == side - 1)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
