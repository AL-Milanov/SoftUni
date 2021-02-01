using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string model;
        public Engine engine;
        public string weight = "n/a";
        public string color = "n/a";

        public string Model { get => model; set => model = value; }

        public Engine CarEngine { get => engine; set => engine = value; }

        public string Weight { get => weight; set => weight = value; }

        public string Color { get => color; set => color = value; }

        public override string ToString()
        {
            return $"{Model}:\n  {CarEngine}\n  Weight: {Weight}\n  Color: {Color}";
        }
    }
}
