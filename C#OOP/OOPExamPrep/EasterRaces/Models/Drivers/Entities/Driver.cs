using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int minNameLenght = 5;
        private string driverName;
        private ICar car;
        private int numberOfWins;
        private bool canParticipate = false;

        public Driver(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => driverName;
            private set
            {

                if (string.IsNullOrWhiteSpace(value) || value.Length < minNameLenght)
                {

                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, minNameLenght));
                }

                driverName = value;
            }
        }

        public ICar Car => car;

        public int NumberOfWins => numberOfWins;

        public bool CanParticipate => canParticipate;

        public void AddCar(ICar car)
        {

            if (car == null)
            {

                throw new ArgumentException(ExceptionMessages.CarInvalid);
            }

            canParticipate = true;
            this.car = car;
        }

        public void WinRace()
        {
            //Should check if Car is not Null ??
            numberOfWins++;
        }
    }
}
