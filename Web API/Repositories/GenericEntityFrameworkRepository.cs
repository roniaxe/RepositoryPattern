using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Web_API.Repositories
{
    public class GenericEntityFrameworkRepository<T, TId> : IRepository<T, TId> where T : class
    {
        private readonly DbContext _dbContext;

        public GenericEntityFrameworkRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(TId id)
        {
            var entity = _dbContext.Find<T>(id);
            _dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public int Delete(T obj)
        {
            _dbContext.Remove(obj);
            return _dbContext.SaveChanges();
        }

        public int Update(T obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int Create(T obj)
        {
            _dbContext.Add(obj);
            return _dbContext.SaveChanges();
        }
    }
}
