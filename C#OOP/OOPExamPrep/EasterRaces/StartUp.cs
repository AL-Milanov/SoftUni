using EasterRaces.Models.Cars;
using EasterRaces.Repositories.Entities;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            CarRepository car = new CarRepository();
            //IChampionshipController controller = null; //new ChampionshipController();
            //IReader reader = new ConsoleReader();
            //IWriter writer = new ConsoleWriter();

            //Engine enigne = new Engine(controller, reader, writer);
            //enigne.Run();
        }
    }
}
