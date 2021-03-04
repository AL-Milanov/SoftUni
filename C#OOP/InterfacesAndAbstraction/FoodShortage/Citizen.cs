namespace FoodShortage
{
    public class Citizen : Id, IHaveBirthday, IBuyer, IHaveNameAndAge
    {
        private int food = 0;

        public Citizen(string name, int age, long id, string birthDate)
        {
            Name = name;
            Age = age;
            IdNumber = id;
            BirthDate = birthDate;
        }

        public string Name { get; set; }

        public int Age { get; set; }
        public long IdNumber { get ; set; }
        public string BirthDate { get ; set ; }
        public int Food => food;

        public int BuyFood()
        {
            return food += 10;
        }
    }
}
