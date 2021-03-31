using EasterRaces.Models.Cars;
using EasterRaces.Models.Races;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;

namespace EasterRaces.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected List<T> models;

        public Repository()
        {
            models = new List<T>();
        }

        public void Add(T model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return models;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return models.Remove(model);
        }
    }
}
