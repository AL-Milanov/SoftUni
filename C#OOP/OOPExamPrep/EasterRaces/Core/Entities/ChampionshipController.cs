using EasterRaces.Core.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository drivers;
        private RaceRepository races;
        private CarRepository cars;

        public ChampionshipController()
        {
            cars = new CarRepository();
            races = new RaceRepository();
            drivers = new DriverRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            throw new NotImplementedException();
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            throw new NotImplementedException();
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            throw new NotImplementedException();
        }

        public string CreateDriver(string driverName)
        {
            Driver driver = new Driver(driverName);

            return null;
        }

        public string CreateRace(string name, int laps)
        {
            throw new NotImplementedException();
        }

        public string StartRace(string raceName)
        {
            throw new NotImplementedException();
        }
    }
}
