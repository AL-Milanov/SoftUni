using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;
        private Computer computer;
        private const string manufacturer = "Asus";
        private const string model = "B-12";
        private const decimal price = 200;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
            computer = new Computer(manufacturer, model, price);
        }

        [Test]
        public void AddComputer_WhenTryToAddNull()
        {
            Computer emptyComputer = null;

            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(emptyComputer));
        }

        [Test]
        public void AddComputer_WithComputerThatIsAlreadyInCollection_ShouldThrowException()
        {
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
        }

        [Test]
        public void AddComputer_WithCorrectData_ShouldIncreaseCount()
        {
            Computer newAsus = new Computer(manufacturer, "New 2021", 1000);
            Computer acer = new Computer("Acer", model, 200);

            computerManager.AddComputer(computer);
            computerManager.AddComputer(newAsus);
            computerManager.AddComputer(acer);

            Assert.That(computerManager.Count, Is.EqualTo(3));
        }

        [Test]
        public void AddComputer_ShouldAddComputerToCollection()
        {
            List<Computer> computers = new List<Computer>();

            for (int i = 0; i < 3; i++)
            {
                Computer customComputer = new Computer($"Custom{i}", "Model{i}", 100 + i);
                computers.Add(customComputer);
                computerManager.AddComputer(customComputer);
            }

            var actual = computerManager.Computers;

            Assert.That(actual, Is.EqualTo(computers));
        }

        [Test]
        [TestCase(null, "SomeModel")]
        [TestCase("SomeManufacturer", null)]
        public void RemoveComputer_WithNullParams_ShouldThrowArgumentNullException(string manufacturer, string model)
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(manufacturer, model));
        }

        [Test]
        public void RemoveComputer_WithCorrectData_ShouldRemoveComputerAndReturnIt()
        {
            computerManager.AddComputer(computer);
            string manufacturer = computer.Manufacturer;
            string model = computer.Model;
            var removedComputer = computerManager.RemoveComputer(manufacturer, model);

            Assert.That(computerManager.Count, Is.Zero);
            Assert.That(removedComputer, Is.EqualTo(computer));
        }

        [Test]
        public void GetComputer_WhenThereIsNotSuchComputer_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("InvalidManufacturer", "InvalidModel"));
        }

        [Test]
        public void GetComputer_WithCorrectData_ShouldReturnComputer()
        {
            computerManager.AddComputer(computer);
            var manufacturer = computer.Manufacturer;
            var model = computer.Model;
            var actualComputer = computerManager.GetComputer(manufacturer, model);

            Assert.That(computer, Is.EqualTo(actualComputer));
        }
        [Test]
        public void GetComputersByManufacturer_WithCorrectData_ShouldReturnComputerCollection()
        {
            computerManager.AddComputer(computer);
            computerManager.AddComputer(new Computer(manufacturer, "new Model", 2000));
            computerManager.AddComputer(new Computer("Msi", "Model", 2000));
            var allByManufacturer = computerManager.GetComputersByManufacturer(manufacturer);

            Assert.That(allByManufacturer.Count, Is.EqualTo(2));
        }
    }
}