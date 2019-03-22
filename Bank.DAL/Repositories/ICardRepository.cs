using System.Collections;
using Bank.DAL.Models;

namespace Bank.DAL.Repositories
{
    public interface ICardRepository : IRepository<Card>
    {
        Card GetById(int cardId);
    }
}