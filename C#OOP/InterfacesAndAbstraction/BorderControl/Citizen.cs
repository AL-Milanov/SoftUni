namespace BorderControl
{
    public class Citizen : Id, IHaveBirthday
    {

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
    }
}
