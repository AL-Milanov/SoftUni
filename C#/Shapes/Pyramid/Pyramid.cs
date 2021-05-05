using Shapes.Contracts;
using System;

namespace Shapes
{
    class Pyramid : IDrawer
    {
        private int height;

        public Pyramid(int height)
        {
            Height = height;
        }

        public int Height { get => height; private set => height = value; }

        public void Draw()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 1; j <= height - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= 2*i -1; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}
