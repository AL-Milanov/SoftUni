namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class BaseVehicleTests
    {
        private const string model = "Raptor";
        private const double weight = 50;
        private const double price = 100;
        private const int attack = 200;
        private const int defense = 250;
        private const int hitPoints = 300;
        private VehicleAssembler assembler;

        [SetUp]
        public void SetUp()
        {
            assembler = new VehicleAssembler();
        }

        [Test]
        [TestCase(null, weight, price, attack, defense, hitPoints)]
        [TestCase("   ", weight, price, attack, defense, hitPoints)]
        [TestCase(model, 0, price, attack, defense, hitPoints)]
        [TestCase(model, -weight, price, attack, defense, hitPoints)]
        [TestCase(model, weight, 0, attack, defense, hitPoints)]
        [TestCase(model, weight, -price, attack, defense, hitPoints)]
        [TestCase(model, weight, price, -50, defense, hitPoints)]
        [TestCase(model, weight, price, attack, -50, hitPoints)]
        [TestCase(model, weight, price, attack, defense, -50)]
        public void Ctor_ShouldThrowArgumentExceptionWhenIncorrectDataIsGiven(
            string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            
            Assert.Throws<ArgumentException>(() => { BaseVehicle baseVehicle = 
                new Revenger(model, weight, price, attack, defense, hitPoints, assembler); });
        }

        [Test]
        public void Parts_ShouldReturnCollection()
        {
            BaseVehicle baseVehicle = new Revenger(model, weight, (decimal)price, attack, defense, hitPoints, assembler);

            
            baseVehicle.AddArsenalPart(new ArsenalPart("Rocket", 50, 50, 50));
            baseVehicle.AddEndurancePart(new EndurancePart("Plate", 50, 50, 50));
            baseVehicle.AddShellPart(new ShellPart("Shell", 50, 50, 50));

            int expected = 3;

            Assert.That(baseVehicle.Parts.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void ToString_ShouldReturnVehicleData()
        {
            BaseVehicle baseVehicle = new Revenger(model, weight, (decimal)price, attack, defense, hitPoints, assembler);

            string expectedResult = string.Empty;

            expectedResult += $"Revenger - {model}" + Environment.NewLine;
            expectedResult += $"Total Weight: {weight:F3}" + Environment.NewLine;
            expectedResult += $"Total Price: {price:F3}" + Environment.NewLine;
            expectedResult += $"Attack: {attack}" + Environment.NewLine;
            expectedResult += $"Defense: {defense}" + Environment.NewLine;
            expectedResult += $"HitPoints: {hitPoints}" + Environment.NewLine;

            expectedResult += ("Parts: None");

            string actualResult = baseVehicle.ToString();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}