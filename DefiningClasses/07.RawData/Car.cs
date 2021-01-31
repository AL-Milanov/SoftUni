using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, int engine, string cargoType, List<double> tires)
        {
            Model = model;
            Engine = engine;
            CargoType = cargoType;
            Tires = tires;
        }
        public string Model { get; set; }
        public int Engine { get; set; }
        public string CargoType { get; set; }
        public List<double> Tires { get; set; }
    }
}
