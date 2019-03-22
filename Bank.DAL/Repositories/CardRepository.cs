using Bank.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank.DAL.Repositories
{
    public class CardRepository : RepositoryBase<Card>, ICardRepository 
    {
        public CardRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Card GetById(int cardId)
        {
            return DbContext.Set<Card>().Find(cardId);
        }
    }
}