namespace FoodShortage
{
    public class Robot : Id
    {

        public Robot(string model, long id)
        {
            Model = model;
            IdNumber = id;
        }

        public string Model { get; set; }

        public long IdNumber { get; set; }
    }
}
