using System;
using System.Collections;
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

        public void Create(Deposit deposit)
        {
            var card = _uow.Repository<Card>().GetById(deposit.CardId);

            if (card is null)
                throw new ArgumentException("Current card does not exist");
            
            if (card.Money < deposit.Money)
                throw new ArgumentException("Client has not enough money to create a deposit");

            if (deposit.EndDate < DateTime.UtcNow)
                throw new ArgumentException("End date is later than current time");
            
            
            deposit.CreationDate = DateTime.UtcNow;
            deposit.WasTaken = false;
            card.Money -= deposit.Money;
            
            _uow.Repository<Deposit>().Add(deposit);
            _uow.SaveChanges();
            _logger.LogDebug("Deposit was successfully created");
        }

        public IEnumerable<Deposit> ViewAllByUserId(int userId)
        {
            return _uow.Repository<Client>().GetById(userId).Cards.SelectMany(c => c.Deposits);
        }

        public void TakeMoney(int userId)
        {
            var deposits = ViewAllByUserId(userId);

            for (int i = 0; i < deposits.Count(); i++)
            {
                var current = deposits.ElementAt(i);

                if (current.WasTaken) continue;

                var months = (current.EndDate - current.CreationDate).Days / 30;

                current.Card.Money += CalculatePercent(current.Money, current.PercentPerMonth, (int)months);
                    
                current.WasTaken = true;
            }      
            
            _uow.SaveChanges();
            
            _logger.LogDebug("Money was taken successfully");
        }
        
        public decimal CalculatePercent(decimal money, decimal percent, int months)
        => (decimal)((double)money * Math.Pow((double)(1 + percent / 100 * 30  / 365 ), months));
        
    }
}