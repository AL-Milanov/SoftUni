using EasterRaces.Models.Cars;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<Car>
    {
        public CarRepository()
        {
        }

        public override Car GetByName(string name)
        {
            var car = models.FirstOrDefault(m => m.Model == name);

            return car;
        }
    }
}
