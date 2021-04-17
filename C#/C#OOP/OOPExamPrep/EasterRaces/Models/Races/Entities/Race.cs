using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int minLaps = 1;
        private const int raceNameLenght = 5;
        private string raceName;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            drivers = new List<IDriver>();
        }

        public string Name 
        { 
            get => raceName;
            private set
            {

                if (string.IsNullOrWhiteSpace(value) || value.Length < raceNameLenght)
                {

                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, raceNameLenght));
                }

                raceName = value;
            }
        }

        public int Laps
        {
            get => laps;
            private set
            {

                if (value < minLaps)
                {

                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, minLaps));
                }

                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {

            if (driver == null)
            {

                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (driver.CanParticipate == false)
            {

                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (drivers.Contains(driver))
            {

                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, Name));
            }

            drivers.Add(driver);
        }
    }
}
