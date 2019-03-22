using System.Linq;
using Bank.DAL.Models;
using Bank.DAL.Repositories;

namespace Bank.DAL.Extensions
{
    public static class ClientRepositoryExtensions
    {
        public static Client GetById(this IRepository<Client> rep, int userId)
        {
            return rep.GetQueryable().SingleOrDefault(c => c.Id == userId);
        }
    }
}