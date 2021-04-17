using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private const int MinAttackHp = 30;
        private const int ValidHp = 100;
        private const int BaseDamage = 30;
        private Warrior warrior;
        private string name = "Warrior";
        private int damage = MinAttackHp * 2;
        private int hp = 100;


        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior(name, damage, hp);
        }

        [Test]
        [TestCase(null, 30, 100)]
        [TestCase("  ", 30, 100)]
        [TestCase("Name", 0, 100)]
        [TestCase("Name", -30, 100)]
        [TestCase("Name", 30, -100)]
        public void When_InitializingCtorWithIncorectData_ShouldThrowArgumentException(
            string name, int damage, int hp)
        {

            Assert.Throws<ArgumentException>(() => { warrior = new Warrior(name, damage, hp); });
        }

        [Test]
        [TestCase(MinAttackHp, ValidHp, BaseDamage)]
        [TestCase(MinAttackHp / 2, ValidHp, BaseDamage)]
        [TestCase(ValidHp, MinAttackHp, BaseDamage)]
        [TestCase(ValidHp, MinAttackHp / 2, BaseDamage)]
        [TestCase(ValidHp, ValidHp, BaseDamage * ValidHp)]
        public void When_AttackWithEqualOrLessThanMinAttackHpAndTryToAttackStrongerOpponent_ShouldThrowException(
            int warriorHp, int opponentHp, int opponentDamage)
        {
            warrior = new Warrior(name, damage, warriorHp);
            Warrior opponend = new Warrior("Opponent", opponentDamage, opponentHp);

            Assert.Throws<InvalidOperationException>(() => { warrior.Attack(opponend); });
        }

        [Test]
        public void When_AttackWithCorrectValues_ShouldReduceWarriorHp()
        {
            Warrior opponent = new Warrior("Opponent", BaseDamage, ValidHp);
            int hpAfterAttack = warrior.HP - opponent.Damage;

            warrior.Attack(opponent);

            Assert.That(warrior.HP, Is.EqualTo(hpAfterAttack));
        }

        [Test]
        [TestCase(ValidHp / 2)]
        [TestCase(ValidHp)]
        public void When_AttackWithCorrectValues_ShouldReduceOpponentHp(int opponentHp)
        {
            Warrior opponent = new Warrior("Opponent", BaseDamage, opponentHp);
            int hpAfterAttack = opponent.HP < warrior.Damage
                ? 0 : opponent.HP - warrior.Damage;

            warrior.Attack(opponent);

            Assert.That(opponent.HP, Is.EqualTo(hpAfterAttack));
        }
    }
}