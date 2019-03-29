using System;
using System.Collections.Generic;
using System.Linq;
using Bank.BL.Services.Abstract;
using Bank.DAL.Extensions;
using Bank.DAL.Models;
using Bank.DAL.Repositories;
using Microsoft.Extensions.Logging;
using static Bank.Common.Constants.ErrorMessages;

namespace Bank.BL.Services.Concrete
{
    public class CardService : ICardService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<CardService> _logger;

        public CardService(IUnitOfWork uow, ILoggerFactory loggerFactory)
        {
            _uow = uow;
            _logger = loggerFactory.CreateLogger<CardService>();
        }

        public void Create(Card card)
        {
            if(string.IsNullOrWhiteSpace(card.Name))
                 throw new ArgumentException(ParameterIsRequired(nameof(card.Name)));
            
            if(Math.Abs(card.CashbackPercent) < 0.2)
                throw new ArgumentException(ParameterIsRequired(nameof(card.CashbackPercent)));
            
            var client = _uow.Repository<Client>().GetById(card.ClientId);

            if (client == null)
                throw new ArgumentException(ParameterIsRequired(nameof(client)));
            
            var random = new Random();

            card.CreationDate = DateTime.UtcNow;
            card.ExpDate = DateTime.UtcNow.AddYears(3);
            
            var firstPart = random.Next(1000_0000, 9999_9999).ToString().PadRight(8);
            var secondPart = random.Next(1000_0000, 9999_9999).ToString().PadRight(8);
            
            card.Number = firstPart + secondPart;

            var cvv2 = random.Next(0, 9999);
            card.CVV2 = cvv2.ToString().PadRight(4);
            card.Money = 10000;
            
            _uow.Repository<Card>().Add(card);
            _uow.SaveChanges();
            
            _logger.LogDebug("Card added successfully");
        }

        public IEnumerable<Card> GetAll(int clientId)
        {
            return _uow.Repository<Card>().GetQueryable().Where(c => c.ClientId == clientId);
        }
    }
}