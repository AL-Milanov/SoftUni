using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private Wall wall;
        private Random random;
        private char symbol;

        protected Food(Wall wall, char foodSymbol, int foodPoints) 
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            symbol = foodSymbol;
            FoodPoints = foodPoints;
            random = new Random();
        }

        public int FoodPoints { get; private set; }


        public void SetRandomPosition(Queue<Point> snake)
        {
            
            LeftX = random.Next(2, wall.LeftX);
            TopY = random.Next(2, wall.TopY);

            while (IsPointOfSnake(snake))
            {
                LeftX = random.Next(2, wall.LeftX);
                TopY = random.Next(2, wall.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Draw(symbol);
        }

        public bool IsFoodEaten(Point snake)
        {
            return snake.LeftX == LeftX && snake.TopY == TopY;
        }

        private bool IsPointOfSnake(Queue<Point> snake)
        {
            return snake.Any(x => x.LeftX == wall.LeftX && x.TopY == wall.TopY);
        }
    }
}
