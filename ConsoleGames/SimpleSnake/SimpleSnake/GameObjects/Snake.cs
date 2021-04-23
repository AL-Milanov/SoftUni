using SimpleSnake.GameObjects.FoodTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake : Point 
    {
        private const char snakeSymbol = '\u25CF';
        private int nextLeftX;
        private int nextTopY;
        private Wall wall;
        private Queue<Point> snakeElements;
        private List<Food> foods;

        public Snake(Wall wall) :
            base(leftX, topY)
        {
            this.wall = wall;
            snakeElements = new Queue<Point>();
            foods = new List<Food>();
            CreateSnake();
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            foods[0] = new FoodHash(wall);
            foods[1] = new FoodDollar(wall);
            foods[2] = new FoodAsterisk(wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead) 
        {
            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;
        }

        public bool IsMoving(Point direction)
        {
            Point snakeHead = snakeElements.Last();

            GetNextPoint(direction, snakeHead);

            bool isPointOfSnake = snakeElements.Any(s => s.LeftX == nextLeftX && s.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point newSnakeHead = new Point(nextLeftX, nextTopY);

            if (wall.IsPositionOfWall(newSnakeHead))
            {
                return false;
            }

            snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw
            return true;
        }
    }
}
