using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person[] people;
        private ExtendedDatabase dataOfPerson;
        private const int maxElements = 16;

        [SetUp]
        public void Setup()
        {
            //NameSpace
            ForCycle(maxElements);

            dataOfPerson = new ExtendedDatabase(people);
        }

        [Test]
        public void When_InitializingDatabaseWithMoreThanSixteenElements_ShouldThrowArgumentExceptionI()
        {
            //namespace
            int biggerNumber = maxElements + 1;
            ForCycle(biggerNumber);

            Assert.That(() => { dataOfPerson = new ExtendedDatabase(people); },
                Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void When_InitializingDatabaseWithSixteenElements_CounterSholdBeSixteen()
        {
            Assert.AreEqual(dataOfPerson.Count, maxElements);
        }

        [Test]
        public void When_TryToAddPersonWhenDatabaseIsFull_ShouldThrowOperationException()
        {
            //namespace
            Person person = new Person(9999, "Az");
            Assert.That(() => { dataOfPerson.Add(person); },
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void When_TryToAddSamePersonTwice_ShouldThrowOperationException()
        {
            //namespace
            Person duplicateNamePerson = new Person(9999, "1Pesho");
            Person duplicateIdPerson = new Person(1, "Gosho"); 
            dataOfPerson.Remove();
            dataOfPerson.Remove();

            Assert.That(() => { dataOfPerson.Add(duplicateNamePerson); },
                Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
            Assert.That(() => { dataOfPerson.Add(duplicateIdPerson); },
                Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void When_AddedOrRemoveElement_ShouldChangeCount()
        {
            //namespace
            dataOfPerson.Remove();
            int countMinusElement = maxElements - 1;

            Assert.AreEqual(countMinusElement, dataOfPerson.Count);

            Person person = new Person(9999, "Mon");
            dataOfPerson.Add(person);
            Assert.AreEqual(maxElements, dataOfPerson.Count);
        }

        [Test]
        public void When_TryToRemoveOnEmptyDatabase_ShouldThrowOperationExeption()
        {
            people = new Person[0];
            dataOfPerson = new ExtendedDatabase(people);

            Assert.That(() => { dataOfPerson.Remove(); }, Throws.InvalidOperationException);
        }

        [Test]
        public void When_TryToFindNameThatIsNullOrEmpty_ShouldThrowArgumentExeption()
        {
            string nameThatIsNull = null;
            //??
            Assert.That(() => { dataOfPerson.FindByUsername(nameThatIsNull); },
                Throws.ArgumentNullException);
        }

        [Test]
        public void When_TryToFindNameThatIsNotPresented_ShouldThrowInvalidOperationExeption()
        {

            string nameThatIsNotPresented = "Yo";

            Assert.That(() => { dataOfPerson.FindByUsername(nameThatIsNotPresented); },
                Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void When_TryToFindNameThatIsCorrectParameter_ShouldReturnPerson()
        {
            //namespace
            Assert.That(dataOfPerson.FindByUsername("1Pesho"), Is.InstanceOf(typeof(Person)));
        }

        [Test]
        public void When_TryToFindIdThatIsNegativeNumber_ShouldThrowArgumentOutOfRangeException()
        {
            long negativeNumber = -2;

            //??
            Assert.That(() => { dataOfPerson.FindById(negativeNumber); },
                Throws.Exception);
        }

        [Test]
        public void When_TryToFIndIdThatIsNotInDatabase_ShouldThrowOperationException()
        {
            long wrongId = 1010101010;

            Assert.That(() => { dataOfPerson.FindById(wrongId); }, 
                Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void When_TryToFindIdThatIsInDatabase_ShouldReturnPerson()
        {
            Assert.That(dataOfPerson.FindById(0), Is.InstanceOf(typeof(Person)));
        }

        private void ForCycle(int length)
        {
            people = new Person[maxElements];

            if (length > maxElements)
            {
                people = new Person[length];
            }

            for (int i = 0; i < length; i++)
            {
                people[i] = new Person(i, $"{i}Pesho");
            }
        }
    }
}