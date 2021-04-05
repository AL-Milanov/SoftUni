using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
            computer = new Computer("Asus", "New 20", 200);
        }

        [Test]
        public void Ctor_CounterIsZeroWhenInitialized()
        {
            Assert.That(computerManager.Count, Is.Zero);
        }

        [Test]
        public void Ctor_WhenInitializedCreatesEmptyListOfComputers()
        {
            IReadOnlyCollection<Computer> expected = new List<Computer>();
            var actual = computerManager.Computers;

            Assert.That(expected, Is.EqualTo(actual));
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
            int countBefore = computerManager.Count;
            computerManager.AddComputer(computer);

            Assert.That(computerManager.Count, Is.EqualTo(countBefore + 1));
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
        [TestCase(null, "SomeModel")]
        [TestCase("SomeManufacturer", null)]
        public void GetComputer_WithNullParameters_ShouldThrowArgumentNullException(string manufacturer, string model)
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(manufacturer, model));
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
            List<Computer> computers = new List<Computer>();
            string manufacturer = "Asus";

            for (int i = 0; i < 5; i++)
            {
                Computer customComputer = new Computer(manufacturer, $"{i}gen", 500);
                computers.Add(customComputer);
                computerManager.AddComputer(customComputer);
            }

            Assert.That(computerManager.GetComputersByManufacturer(manufacturer), Is.EqualTo(computers));
        }
        [Test]
        public void GetComputersByManufacturer_WithNullData_ShouldReturnComputerCollection()
        {
            string manufacturer = null;

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(manufacturer));
        }
    }
}