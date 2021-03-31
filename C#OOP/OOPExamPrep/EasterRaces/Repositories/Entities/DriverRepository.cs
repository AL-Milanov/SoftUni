using EasterRaces.Models.Drivers;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<Driver>
    {
        public DriverRepository()
        {
        }

        public override Driver GetByName(string name)
        {
            var driver = models.FirstOrDefault(d => d.Name == name);

            return driver;
        }
    }
}
