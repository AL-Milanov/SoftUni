﻿using System;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(params int[] side)
            : base(side)
        {
            SideY = side[0];
            SideX = side[1];
        }

        public int SideY { get; private set; }

        public int SideX { get; private set; }

        public override void Draw()
        {
            for (int i = 0; i < SideX; i++)
            {
                for (int j = 0; j < SideY; j++)
                {

                    if (i != 0 && i != SideX - 1)
                    {
                        if (j == 0 || j == SideY - 1)
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
