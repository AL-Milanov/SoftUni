using EasterRaces.Models.Races;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<Race>
    {
        public RaceRepository()
        {
        }

        public override Race GetByName(string name)
        {
            var race = models.FirstOrDefault(r => r.Name == name);

            return race;
        }
    }
}
