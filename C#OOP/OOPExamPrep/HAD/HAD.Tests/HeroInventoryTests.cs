using HAD.Entities.Items;
using HAD.Entities.Miscellaneous;
using NUnit.Framework;
using System.Collections.Generic;

namespace HAD.Tests
{

    public class HeroInventoryTests
    {
        private HeroInventory heroInventory;
        private CommonItem axe;
        private CommonItem sword;
        private int axeStats = 100;
        private int swordStats = 200;

        [SetUp]
        public void Setup()
        {
            heroInventory = new HeroInventory();
            axe = new CommonItem("Axe", axeStats, axeStats, axeStats, axeStats, axeStats);
            sword = new CommonItem("Sword", swordStats, swordStats, swordStats, swordStats, swordStats);

            heroInventory.AddCommonItem(axe);
            heroInventory.AddCommonItem(sword);
        }

        [Test]
        public void TotalStatBonus_ShouldReturnSumOfStatsFromItems()
        {
            int strSum = axeStats + swordStats;

            Assert.That(heroInventory.TotalStrengthBonus, Is.EqualTo(strSum));
            Assert.That(heroInventory.TotalAgilityBonus, Is.EqualTo(strSum));
            Assert.That(heroInventory.TotalIntelligenceBonus, Is.EqualTo(strSum));
            Assert.That(heroInventory.TotalHitPointsBonus, Is.EqualTo(strSum));
            Assert.That(heroInventory.TotalDamageBonus, Is.EqualTo(strSum));

        }

        [Test]
        public void CommonItems_ShouldReturnCollection()
        {
            List<BaseItem> collection = new List<BaseItem>();
            collection.Add(axe);
            collection.Add(sword);

            Assert.That(heroInventory.CommonItems, Is.EqualTo(collection));
            
        }

        [Test]
        public void AddCommonItem_ShouldAddCommonItemInCollection()
        {
            BaseItem bow = new CommonItem("Bow", 1, 1, 1, 1, 1);
            heroInventory.AddCommonItem(bow);

            Assert.DoesNotThrow(() => heroInventory.AddCommonItem(bow));
        }

        [Test]
        public void AddRecipeItem_ShouldAddRecipeItemInCollection()
        {
            List<string> requiredItems = new List<string>()
            {
                "Stick",
                "Rope"
            };

            RecipeItem bow = new RecipeItem("Bow", 1, 1, 1, 1, 1, requiredItems);

            Assert.DoesNotThrow(() => heroInventory.AddRecipeItem(bow));
        }
    }
}