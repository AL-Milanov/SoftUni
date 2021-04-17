namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            FamilyCar car = new FamilyCar(202, 20);
            car.Drive(2);
            System.Console.WriteLine(car.Fuel);


        }
    }
}
