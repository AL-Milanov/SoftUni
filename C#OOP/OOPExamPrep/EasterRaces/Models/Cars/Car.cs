using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : CarRepository, ICar
    {
        private const int minModelLenght = 4;
        private string model;
        private int horsePower;
        private readonly int minHorsePower;
        private readonly int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => model;
            private set
            {

                if (string.IsNullOrWhiteSpace(value) || value.Length < minModelLenght)
                {

                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, minModelLenght));
                }

                model = value;
            }
        }

        public int HorsePower 
        {
            get => horsePower;
            private set
            {

                if (value < minHorsePower || value > maxHorsePower)
                {

                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                horsePower = value;
            } 
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            double calculatedRacePoints = (CubicCentimeters / HorsePower) * laps;

            return calculatedRacePoints;
        }
    }
}
