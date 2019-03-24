using System.Collections;
using System.Collections.Generic;
using Bank.DAL.Models;

namespace Bank.BL.Services.Abstract
{
    public interface ICardService
    {
        void Create(Card card);
        
        IEnumerable<Card> GetAll(int clientId);
    }
}