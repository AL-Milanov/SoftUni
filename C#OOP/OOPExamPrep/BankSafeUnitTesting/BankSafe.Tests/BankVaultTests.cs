using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private const string ValidCell = "A1";
        private string itemOwner = "Alex";
        private string itemId = "123456";
        private BankVault bankVault;
        private Item item;

        [SetUp]
        public void Setup()
        {

            bankVault = new BankVault();
            item = new Item(itemOwner, itemId);
        }

        [Test]
        public void When_CtorIsInitialized_ShouldCreateDictionaryWithTwelveElements()
        {

            Assert.That(bankVault.VaultCells.Count, Is.EqualTo(12));
        }

        [Test]
        public void When_AddItemWithInvalidCellName_ShouldThrowArgumentException()
        {

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("Invalid", new Item(itemOwner, itemId)));
        }

        [Test]
        public void When_AddItemToCellThatIsOccupied_ShouldThrowArgumentException()
        {

            Item newItem = new Item("Other name", "12");
            bankVault.AddItem(ValidCell, item);

            Assert.Throws<ArgumentException>(() => bankVault.AddItem(ValidCell, newItem));
        }

        [Test]
        public void When_AddItemThatIsAlreadyInAnotherCell_ShouldThrowInvalidOperationException()
        {
            string anotherValidCell = "B1";
            bankVault.AddItem(ValidCell, item);

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem(anotherValidCell, item));
        }

        [Test]
        public void When_AddItemWithCorrectData_ShouldReturnStringAndOccupyCell()
        {

            string expectedOutput = $"Item:{item.ItemId} saved successfully!";
            Assert.That(bankVault.AddItem(ValidCell, item), Is.EqualTo(expectedOutput));
            Assert.That(bankVault.VaultCells[ValidCell], Is.EqualTo(item));
        }

        [Test]
        public void When_RemoveItemWithIncorectCellName_ShouldThrowArgumentException()
        {

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("InvalidCell", item));
        }

        [Test]
        public void When_RemoveItemWithDifferentItemThatIsInCell_ShouldThrowArgumentException()
        {

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(ValidCell, item));
        }

        [Test]
        public void When_RemoveItemWithCorrectData_ShouldReturnStringAndFreeCell()
        {
            bankVault.AddItem(ValidCell, item);
            string expectedOutput = $"Remove item:{item.ItemId} successfully!";

            Assert.That(bankVault.RemoveItem(ValidCell, item), Is.EqualTo(expectedOutput));
            Assert.That(bankVault.VaultCells[ValidCell], Is.EqualTo(null));
        }
    }
}