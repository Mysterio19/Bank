using System.Collections.Generic;
using System.Linq;
using Bank.DAL.Models;

namespace Bank.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity: Entity
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> Add(IReadOnlyCollection<TEntity> entities);
        IQueryable<TEntity> GetQueryable();
        void Delete(TEntity entity);
        void Delete(IReadOnlyCollection<TEntity> entities);
    }
}