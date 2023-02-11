using System.Collections.Generic;

namespace ContactManagement.Domain.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        TEntity Get(int id);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        void Delete(int id);
    }
}