namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.FoodTypes;
    using Utilities;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            Wall wall = new Wall(100, 40);
            Food food = new FoodDollar(wall);
            Snake sna = new Snake();

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
