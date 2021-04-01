using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> drivers;
        private readonly IRepository<IRace> races;
        private readonly IRepository<ICar> cars;

        public ChampionshipController()
        {
            cars = new CarRepository();
            races = new RaceRepository();
            drivers = new DriverRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = drivers.GetByName(driverName);
            ICar car = cars.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            cars.Remove(car);
            return $"{string.Format(OutputMessages.CarAdded, driverName, carModel)}";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = races.GetByName(raceName);
            IDriver driver = drivers.GetByName(driverName);

            if (race == null)
            {

                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driver == null)
            {

                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            drivers.Remove(driver);
            return $"{string.Format(OutputMessages.DriverAdded, driverName, raceName)}";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type.Contains("Sports"))
            {
                car = new SportsCar(model, horsePower);
            }
            else if (type.Contains("Muscle"))
            {
                car = new MuscleCar(model, horsePower);
            }

            if (drivers.GetByName(model) != null)
            {

                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            cars.Add(car);
            return $"{string.Format(OutputMessages.CarCreated, car.GetType().Name, model)}";
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            if (drivers.GetByName(driverName) != null)
            {

                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            drivers.Add(driver);
            return $"{string.Format(OutputMessages.DriverCreated, driverName)}";
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            if (races.GetByName(name) != null)
            {

                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            races.Add(race);
            return $"{string.Format(OutputMessages.RaceCreated, name)}";
        }

        public string StartRace(string raceName)
        {
            IRace race = races.GetByName(raceName);

            if (race == null)
            {

                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {

                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var winners = race.Drivers.OrderByDescending(c => c.Car.CalculateRacePoints(race.Laps));
            StringBuilder sb = new StringBuilder();
            int i = 1;

            foreach (var winner in winners)
            {
                if (i == 1)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, winner.Name, raceName));
                }
                else if (i == 2)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, winner.Name, raceName));
                }
                else if (i == 3)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, winner.Name, raceName));
                    break;
                }

                i++;
            }

            races.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
