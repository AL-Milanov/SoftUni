using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;

        [SetUp]
        public void SetUp()
        {

            database = new ExtendedDatabase();
        }

        [Test]
        public void When_AddRangeTryToAddDataWithMoreThanSixTeenElements_ShouldThrowArgumentException()
        {
            Person[] people = new Person[17];
            
            for (int i = 0; i < people.Length; i++)
            {
                Person person = new Person(i, $"Username{i}");
                people[i] = person;
            }

            Assert.Throws<ArgumentException>
                (() => { database = new ExtendedDatabase(people); });
        }

        [Test]
        [TestCase(16)]
        [TestCase(9)]
        public void When_AddRangeTryToAddDataWithCorrectLength_ShouldAddToDataBaseAndSetCounterToLenth(int length)
        {
            Person[] people = new Person[length];

            for (int i = 0; i < length; i++)
            {
                Person person = new Person(i, $"Username{i}");
                people[i] = person;
            }

            database = new ExtendedDatabase(people);

            Assert.That(database.Count, Is.EqualTo(length));
        }

        [Test]
        public void When_AddPersonInFullDatabase_ShouldThrowInvalidOperationException()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < people.Length; i++)
            {
                Person person = new Person(i, $"Username{i}");
                people[i] = person;
            }
            database = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => { database.Add(new Person(123, "Pesho")); });
        }

        [Test]
        [TestCase(0, 0, "Pesho", "Other")]
        [TestCase(1234, 1, "Mon", "Mon")]
        public void When_AddPersonWithDuplicateIdOrName_ShouldThrowInvalidOperationException(
            long id, long duplicateId, string userName, string duplicateName)
        {
            Person person = new Person(id, userName);
            Person duplicatePerson = new Person(duplicateId, duplicateName);
            database.Add(person);

            Assert.Throws<InvalidOperationException>(() => { database.Add(duplicatePerson); });
        }

        [Test]
        public void When_AddNewPerson_ShouldPushItAtLastIndex()
        {
            int count = 3;
            
            for (int i = 0; i < count; i++)
            {

                Person person = new Person(i, $"UserName{i}");
                database.Add(person);
            }

            Assert.That(database.Count, Is.EqualTo(count));
        }

        [Test]
        public void When_RemoveAtEmptyDatabase_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => { database.Remove(); });
        }

        [Test]
        public void When_RemoveAtDatabaseWithElements_ShouldRemoveLastElement()
        {
            int count = 4;
            int removeCount = 2;

            for (int i = 0; i < count; i++)
            {

                Person person = new Person(i, $"UserName{i}");
                database.Add(person);
            }

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            Assert.That(database.Count, Is.EqualTo(count - removeCount));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void When_FindByUsernameIsCalledWithNameEqualToNull_ShouldThrowArgumentNullException(string name)
        {

            Assert.Throws<ArgumentNullException>(() => { database.FindByUsername(name); });
        }

        [Test]
        public void When_FindByUsernameIsCalledWithNotPresentedName_ShouldThrowInvalidOperationException()
        {
            string notPresentName = "Aa";

            Assert.Throws<InvalidOperationException>(() => { database.FindByUsername(notPresentName); });
        }

        [Test]
        public void When_FindByUsernameIsCalledWithExistingName_ShouldReturnPerson()
        {
            string name = "Alex";

            Person person = new Person(0, name);
            database.Add(person);
            var databasePerson = database.FindByUsername(name);

            Assert.That(databasePerson, Is.EqualTo(person));
        }

        [Test]
        public void When_FindByIdsIsCalledWithNegativeNumber_ShouldThrowArgumentOutOfRangeException()
        {
            long negativeNumber = -50;

            Assert.Throws<ArgumentOutOfRangeException>(() => { database.FindById(negativeNumber); });
        }

        [Test]
        public void When_FindByIdsIsCalledWithNotPresentedId_ShouldThrowInvalidOperationException()
        {
            long notPresentId = 1010101;

            Assert.Throws<InvalidOperationException>(() => { database.FindById(notPresentId) ; });
        }
        [Test]
        public void When_FindByIdsIsCalledWithExistingId_ShouldReturnPerson()
        {
            long id = 0;

            Person person = new Person(id, "Alex");
            database.Add(person);
            var databasePerson = database.FindById(id);

            Assert.That(databasePerson, Is.EqualTo(person));
        }
    }
}