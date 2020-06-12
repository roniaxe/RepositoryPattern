using System.Collections.Generic;

namespace Web_API.Repositories
{
    public interface IRepository<T, in TId>
    {
        public IEnumerable<T> GetAll();
        public T GetById(TId id);
        public int Delete(T obj);
        public int Update(T obj);
        public int Create(T obj);
    }
}