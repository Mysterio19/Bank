using Bank.BL.Services.Abstract;
using Bank.DAL.Extensions;
using Bank.DAL.Models;
using Bank.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Bank.BL.Services.Concrete
{
    public class SendMoneyService : ISendMoneyService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILoggerFactory _loggerFactory;

        public SendMoneyService(IUnitOfWork uow, ILoggerFactory loggerFactory)
        {
            _uow = uow;
            _loggerFactory = loggerFactory;
        }

        public void SendMoney(Transaction transaction)
        {
            transaction.CreatedAt = transaction.UpdateAt = DateTime.UtcNow;
            transaction.IsDeleted = false;
            transaction.Comment = transaction.Comment == null ? string.Empty : transaction.Comment;
            
            _uow.Repository<Transaction>().Add(transaction);
        }

        public Client GetClientByCardNumber(string cardNumber)
        {
             return _uow.Repository<Client>().GetQueryable()
                .FirstOrDefault((client) => client.Cards.Any(card => card.Number == cardNumber));

        }
    }
}
