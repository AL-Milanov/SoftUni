using Microsoft.EntityFrameworkCore;

namespace FootballManager.Data.Common
{
    public class Repository : IRepository
    {
        private FootballManagerDbContext _context;

        public Repository(FootballManagerDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T model) where T : class
        {
            DbSet<T>().Add(model);

            SaveChanges();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return 1;
            }
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return _context.Set<T>();
        }
    }
}
