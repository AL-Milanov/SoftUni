using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private const int BaseAttack = 50;
        private const int BaseHp = 50;

        private Arena arena;

        [SetUp]
        public void Setup()
        {

            arena = new Arena();
        }

        [Test]
        public void When_WarriorsPropReturnsList_ShouldReturnList()
        {
            List<Warrior> warriors = new List<Warrior>();

            for (int i = 0; i < 5; i++)
            {
                Warrior warrior = new Warrior($"Warrior{i}", BaseAttack, BaseHp);
                warriors.Add(warrior);
                arena.Enroll(warrior);
            }

            Assert.That(arena.Warriors, Is.EqualTo(warriors));
        }

        [Test]
        public void When_EnrollDuplicateWarrior_ShouldThrowInvalidOperationException()
        {
            Warrior warrior = new Warrior("Warrior", BaseAttack, BaseHp);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => { arena.Enroll(warrior); });
        }

        [Test]
        public void When_EnrollWarriors_ShouldIncreaseArenaCount()
        {
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                Warrior warrior = new Warrior($"Warrior{i}", BaseAttack, BaseHp);

                arena.Enroll(warrior);
            }

            Assert.That(arena.Count, Is.EqualTo(count));
        }

        [Test]
        [TestCase("Attacker","Attacker", "Pesho", "Defender")]
        [TestCase("Pesho","Attacker", "Defender", "Defender")]
        public void When_FightCheckIfNamesAreNull_ShouldThrowInvalidOperationException(
            string existingAttackerName, string attackerName, string existingDefenderName, string defenderName)
        {
            Warrior attacker = new Warrior(existingAttackerName, BaseAttack, BaseHp);
            Warrior defender = new Warrior(existingDefenderName, BaseAttack, BaseHp);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => { arena.Fight(attackerName, defenderName); });
        }

        [Test]
        public void When_FightBothWarriors_ShouldLoseHP()
        {
            int initialHp = 100;

            Warrior attacker = new Warrior("Attacker", BaseAttack, initialHp);
            Warrior defender = new Warrior("Defender", BaseAttack, initialHp);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP, Is.EqualTo(initialHp - defender.Damage));
            Assert.That(defender.HP, Is.EqualTo(initialHp - attacker.Damage));
        }
    }
}
