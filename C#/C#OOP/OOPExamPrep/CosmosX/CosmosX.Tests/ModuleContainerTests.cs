namespace CosmosX.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ModuleContainerTests
    {
        private const int cap = 2;
        private ModuleContainer moduleContainer;

        [SetUp]
        public void SetUp()
        {
            moduleContainer = new ModuleContainer(cap);
        }

        [Test]
        public void TotalEnergyOutput_ShouldReturnSumOfEnergy()
        {
            int energy = 100;

            CryogenRod cryogenRod = new CryogenRod(1, energy);
            moduleContainer.AddEnergyModule(cryogenRod);

            Assert.That(moduleContainer.TotalEnergyOutput, Is.EqualTo(energy));
        }


        [Test]
        public void TotalHeatOutput_ShouldReturnSumOfHeat()
        {
            int heat = 100;

            CooldownSystem cooldownSystem = new CooldownSystem(1, heat);
            moduleContainer.AddAbsorbingModule(cooldownSystem);

            Assert.That(moduleContainer.TotalHeatAbsorbing, Is.EqualTo(heat));
        }

        [Test]
        public void AddEnergyModule_WithNullValueShouldThrowException()
        {
            CryogenRod cryogenRod = null;

            Assert.Throws<ArgumentException>(() =>
            moduleContainer.AddEnergyModule(cryogenRod));
        }

        [Test]
        public void AddEnergyModule_WhenIsCapedShouldRemoveFirstElementAndAddNew()
        {
            CryogenRod firstCryogenRod = new CryogenRod(1, 100);
            CryogenRod secondCryogenRod = new CryogenRod(2, 100);
            CryogenRod thirdCryogenRod = new CryogenRod(3, 100);
            moduleContainer.AddEnergyModule(firstCryogenRod);
            moduleContainer.AddEnergyModule(secondCryogenRod);
            moduleContainer.AddEnergyModule(thirdCryogenRod);
            var expected = new List<IEnergyModule>()
            {
                secondCryogenRod,
                thirdCryogenRod
            };
            var modulesByInput = moduleContainer.ModulesByInput;

            Assert.That(modulesByInput, Is.EqualTo(expected));
        }

        [Test]
        public void AddEnergyModule_ShouldAddItInCollection()
        {
            CryogenRod firstCryogenRod = new CryogenRod(1, 100);
            moduleContainer.AddEnergyModule(firstCryogenRod);
            
            Assert.That(moduleContainer.ModulesByInput.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddAbsorbingModule_WithNullValueShouldThrowException()
        {
            CooldownSystem cooldownSystem = null;

            Assert.Throws<ArgumentException>(() =>
            moduleContainer.AddAbsorbingModule(cooldownSystem));
        }

        [Test]
        public void AddAbsorbingModule_WhenIsCapedShouldRemoveFirstElementAndAddNew()
        {
            CooldownSystem firstCooldownSystem = new CooldownSystem(1, 100);
            CooldownSystem secondCooldownSystem = new CooldownSystem(2, 100);
            CooldownSystem thirdCooldownSystem = new CooldownSystem(3, 100);
            moduleContainer.AddAbsorbingModule(firstCooldownSystem);
            moduleContainer.AddAbsorbingModule(secondCooldownSystem);
            moduleContainer.AddAbsorbingModule(thirdCooldownSystem);
            var expected = new List<IAbsorbingModule>()
            {
                secondCooldownSystem,
                thirdCooldownSystem
            };
            var modulesByInput = moduleContainer.ModulesByInput;

            Assert.That(modulesByInput, Is.EqualTo(expected));
        }

        [Test]
        public void AddAbsorbingModule_ShouldAddItInCollection()
        {
            CooldownSystem firstCooldownSystem = new CooldownSystem(1, 100);
            moduleContainer.AddAbsorbingModule(firstCooldownSystem);

            Assert.That(moduleContainer.ModulesByInput.Count, Is.EqualTo(1));
        }
    }
}