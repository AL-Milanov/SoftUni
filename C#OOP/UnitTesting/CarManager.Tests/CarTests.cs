using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private double fuelCapacity = 100;
        private Car car;


        [SetUp]
        public void SetUp()
        {
            car = new Car("Make", "Model", 10, fuelCapacity);
        }


        [Test]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("", "Model", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", "Model", -10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", 10, -100)]
        public void When_InitializingCtorWithIncorrectData_ShouldThrowArgumentException(
            string make, string model, double fuelConsumption, double fuelCapacity)
        {

            Assert.Throws<ArgumentException>(() => { car = new Car(make, model, fuelConsumption, fuelCapacity); });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-50)]
        public void When_RefuelWithNegativeOrZeroFuel_ShouldThrowArgumentException(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => { car.Refuel(fuelToRefuel); });
        }

        [Test]
        public void When_RefuelWithPositiveFuel_ShouldIncreaseFuelAmount()
        {
            double fuelToRefuel = fuelCapacity / 2;
            double refueled = fuelToRefuel + car.FuelAmount;

            car.Refuel(fuelToRefuel);
            Assert.That(car.FuelAmount, Is.EqualTo(refueled));
        }

        [Test]
        public void When_RefuelWithMoreFuelThanTankCapacity_ShouldSetFuelAmountToTankCapacity()
        {
            double fuelToRefuel = fuelCapacity + 1;
            car.Refuel(fuelToRefuel);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void When_DriveToDistanceAndDontHaveEnoughFuel_ShouldThrowInvalidOperationException()
        {
            double bigDistance = 10;

            Assert.Throws<InvalidOperationException>(() => { car.Drive(bigDistance); });
        }

        [Test]
        [TestCase(10)]
        [TestCase(1000)]
        public void When_DriveToDistanceAndHaveEnoughFuel_ShouldReduceFuelAmount(double distance)
        {
            car.Refuel(fuelCapacity);
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            double fuelAfterDrive = car.FuelAmount - fuelNeeded;
            car.Drive(distance);

            Assert.That(car.FuelAmount, Is.EqualTo(fuelAfterDrive));
        }
    }
}