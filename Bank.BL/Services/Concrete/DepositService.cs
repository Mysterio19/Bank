using System;
using System.Collections.Generic;
using System.Linq;
using Bank.BL.Services.Abstract;
using Bank.DAL.Extensions;
using Bank.DAL.Models;
using Bank.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace Bank.BL.Services.Concrete
{
    public class DepositService : IDepositService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<DepositService> _logger;

        public DepositService(IUnitOfWork uow, ILoggerFactory loggerFactory)
        {
            _uow = uow;
            _logger = loggerFactory.CreateLogger<DepositService>();
        }

        public void Create(int cardId, Deposit deposit)
        {
            var card = _uow.CardRepository.GetById(cardId);

            if (card is null)
                throw new ArgumentException("Current card does not exist");
            
            if (card.Money < deposit.Money)
                throw new ArgumentException("Client has not enough money to create a deposit");

            if (deposit.EndDate < DateTime.UtcNow)
                throw new ArgumentException("End date is later than current time");
                
            _uow.Repository<Deposit>().Add(deposit);
            
            _logger.LogDebug("Deposit was successfully created");
        }

        public IEnumerable<Deposit> ViewAllByUserId(int userId)
        {
            return _uow.Repository<Client>().GetById(userId).Cards.SelectMany(c => c.Deposits);
        }
    }
}