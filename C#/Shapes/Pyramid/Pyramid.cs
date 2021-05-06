using System;

namespace Shapes
{
    public class Pyramid : Shape
    {
        private int height;

        public Pyramid(params int[] height)
            :base(height)
        {
            Height = height[0];
        }

        public int Height { get => height; private set => height = value; }

        public override void Draw()
        {
            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= height - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}
