namespace FootballManager.Data.Common
{
    public interface IRepository
    {
        void Add<T>(T model) where T : class;

        IQueryable<T> All<T>() where T : class;

        int SaveChanges();
    }
}
