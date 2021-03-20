using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private const int requiredLength = 16;
        private Database.Database database;
        private int[] data;
        private int testLength = 1;

        [SetUp]
        public void Setup()
        {
            data = new int[requiredLength];
            database = new Database.Database(data);
        }

        [Test]

        public void When_InicialaziedConstructor_ShouldHaveSixteenElements()
        {
            Assert.AreEqual(database.Count, requiredLength);
        }

        [Test]

        public void When_ArrayHaveSpaceAndTryToAdd_ShouldAddInTheArray()
        {
            database = new Database.Database(new int[testLength]);
            database.Add(1);
            Assert.AreEqual(database.Count, testLength + 1);
        }

        [Test]
        public void When_TryToAddElementInFullArray_ShouldThrowExeption()
        {
            
            Assert.That(() => { database.Add(1); }, 
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]

        public void When_TryToRemoveOnEmptyCollection_ShouldThrowExeption()
        {
            database = new Database.Database(new int[testLength]);
            database.Remove();
            Assert.That(() => { database.Remove(); },
                Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]

        public void When_TryToRemoveOnCollectionWithElements_ShouldRemoveLastAndLowerCount()
        {
            database.Remove();
            Assert.AreEqual(database.Count, requiredLength - 1);
        }

        [Test]

        public void When_InvokeMethodFetch_ShouldReturnArray()
        {
            int[] array = database.Fetch();
            Assert.That(array, Is.EqualTo(data));
        }
    }
}