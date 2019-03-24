using System.Collections.Generic;
using Bank.BL.Services.Abstract;
using Bank.DAL.Models;
using Bank.DAL.Repositories;

namespace Bank.BL.Services.Concrete
{
    public class CardService : ICardService
    {
        private readonly IUnitOfWork _uow;

        public CardService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Create(Card card)
        {
            
        }

        public IEnumerable<Card> GetAll(int clientId)
        {
            return new List<Card>();
        }
    }
}