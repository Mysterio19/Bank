using System;
using System.Linq;
using System.Threading.Tasks;
using Bank.DAL.Models;
using Bank.DAL.Repositories;

namespace Bank.DAL.Extensions
{
    public static class EntityRepositoryExtensions
    {
        public static T GetById<T>(this IRepository<T> rep, int? entityId) where T: Entity
        {
            if (!entityId.HasValue)
            {
                throw new ArgumentNullException(nameof(entityId));
            }
            
            return rep.GetQueryable().SingleOrDefault(c => c.Id == entityId);
        }
    }
}