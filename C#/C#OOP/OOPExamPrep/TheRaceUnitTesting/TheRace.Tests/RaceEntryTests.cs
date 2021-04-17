using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private const string driverName = "Alex";
        private const string model = "Mercedes";
        private const int horsePower = 300;
        private const double cubicCentimeters = 3000;
        private const int minParticipants = 2;
        private RaceEntry race;
        private UnitDriver driver;
        private UnitCar car;


        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
            car = new UnitCar(model, horsePower, cubicCentimeters);
            driver = new UnitDriver(driverName, car);
        }

        [Test]
        public void Ctor_ShouldCreateEmptyDictionary()
        {

            Assert.That(race.Counter, Is.EqualTo(0));
        }

        [Test]
        public void AddDriver_WithNullParameter_ShouldThrowInvalidOperationException()
        {
            UnitDriver unitDriver = null;
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(unitDriver));
        }

        [Test]
        public void AddDriver_WithDuplicateDriver_ShouldThrowInvalidOperationException()
        {
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void AddDriver_WithCorrectData_ShouldAddDriverToCollectionAndReturnString()
        {

            string expected = $"Driver {driver.Name} added in race.";

            Assert.That(race.AddDriver(driver), Is.EqualTo(expected));
            Assert.That(race.Counter, Is.EqualTo(1));
        }

        [Test]
        public void CalculateAverageHorsePower_WithLessThanMinParticipants_ShouldThrowInvalidOperationException()
        {

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_WithCorrectData_SholdReturnAverageHorsePower()
        {
            race.AddDriver(driver);
            UnitDriver newDriver = new UnitDriver("Vili", car);
            race.AddDriver(newDriver);

            int expected = car.HorsePower;

            Assert.That(race.CalculateAverageHorsePower(), Is.EqualTo(expected));
        }
    }
}