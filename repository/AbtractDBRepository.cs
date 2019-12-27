using System.Data.Entity;

namespace WpfApp.repository
{
    internal abstract class AbstractDBRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> dataSet;
        protected readonly DbContext dbContext;

        protected AbstractDBRepository(DbSet<T> dataSet, DbContext dbContext)
        {
            this.dataSet = dataSet;
            this.dbContext = dbContext;
        }

        public void Clear()
        {
            foreach (var entity in dataSet)
                dataSet.Remove(entity);
            dbContext.SaveChanges();
        }

        public void Delete(T value)
        {
            dataSet.Remove(value);
            dbContext.SaveChanges();
        }

        public T Insert(T value)
        {
            T t = dataSet.Add(value);
            dbContext.SaveChanges();
            return t;
        }
        public T Update(T value)
        {
            dbContext.SaveChanges();
            return value;
        }
    }
}