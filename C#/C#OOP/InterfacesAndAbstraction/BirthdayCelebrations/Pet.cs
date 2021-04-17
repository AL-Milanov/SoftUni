namespace BirthdayCelebrations
{
    public class Pet : IHaveBirthday
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; set ; }
        public string BirthDate { get ; set; }
    }
}
