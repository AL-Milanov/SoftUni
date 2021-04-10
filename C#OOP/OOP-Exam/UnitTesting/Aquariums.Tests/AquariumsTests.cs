namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class AquariumsTests
    {

        [Test]
        public void Ctor_InitializedWithIncorrectName_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => { Aquarium aquarim = new Aquarium(null, 5); });
        }

        [Test]
        public void Ctor_InitializedWithLessThanZeroCapacity_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => { Aquarium aquarim = new Aquarium("Something", -1); });
        }

        [Test]
        public void Name_ShouldReturnCorrectName()
        {
            string name = "Something";
            Aquarium aquarium = new Aquarium(name, 5);

            Assert.That(aquarium.Name, Is.EqualTo(name));
        }

        [Test]
        public void Capacity_ShouldReturnCorrectCapacity()
        {
            int cap = 5;
            Aquarium aquarium = new Aquarium("Something", cap);

            Assert.That(aquarium.Capacity, Is.EqualTo(cap));
        }

        [Test]
        public void Add_WhenCapacityIsFull_ShouldThrowInvalidOperationException()
        {
            Aquarium aquarim = new Aquarium("Something", 0);

            Assert.Throws<InvalidOperationException>(() => aquarim.Add(new Fish("Pesho")));
        }

        [Test]
        public void Add_ShouldIncreaseCapacity()
        {
            Aquarium aquarim = new Aquarium("Something", 5);
            aquarim.Add(new Fish("Pesho"));

            int expectedCapacity = 1;
            int actualCapacity = aquarim.Count;

            Assert.That(actualCapacity, Is.EqualTo(expectedCapacity));
        }

        [Test]
        public void RemoveFish_WhichIsNotInCollection_ShouldThrowInvalidOperationException()
        {
            Aquarium aquarim = new Aquarium("Something", 5);
            aquarim.Add(new Fish("Pesho"));

            Assert.Throws<InvalidOperationException>(() => aquarim.RemoveFish("Invalid Name"));
        }

        [Test]
        public void RemoveFish_ShouldRemoveIt()
        {
            string fishName = "Pesho";
            Aquarium aquarim = new Aquarium("Something", 5);
            aquarim.Add(new Fish(fishName));
            aquarim.RemoveFish(fishName);

            Assert.That(aquarim.Count, Is.Zero);
        }

        [Test]
        public void SellFish_WhichIsNotInCollection_ShouldThrowInvalidOperationException()
        {
            Aquarium aquarim = new Aquarium("Something", 5);
            aquarim.Add(new Fish("Pesho"));

            Assert.Throws<InvalidOperationException>(() => aquarim.SellFish("Invalid Name"));
        }


        [Test]
        public void SellFish_ShouldReturnFish()
        {
            string fishName = "Pesho";
            var peshoFish = new Fish(fishName);

            Aquarium aquarim = new Aquarium("Something", 5);
            aquarim.Add(peshoFish);

            var requestedFish = aquarim.SellFish(fishName);

            Assert.That(requestedFish, Is.EqualTo(peshoFish));
            Assert.That(requestedFish.Available, Is.False);
        }

        [Test]
        public void Report_ShouldReturnString()
        {
            string aquarimName = "Something";
            List<Fish> fish = new List<Fish>()
            {
                new Fish("Pesho"),
                new Fish("Mariq")
            };
            Aquarium aquarim = new Aquarium(aquarimName, 5);
            aquarim.Add(new Fish("Pesho"));
            aquarim.Add(new Fish("Mariq"));

            string expected = $"Fish available at {aquarimName}: {string.Join(", ", fish.Select(f => f.Name))}";

            Assert.That(aquarim.Report(), Is.EqualTo(expected));
        }
    }
}
