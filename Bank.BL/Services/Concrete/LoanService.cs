using System;
using System.Collections.Generic;
using System.Linq;
using Bank.BL.Services.Abstract;
using Bank.Common.Constants;
using Bank.DAL.Extensions;
using Bank.DAL.Models;
using Bank.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace Bank.BL.Services.Concrete
{
    public class LoanService : ILoanService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<LoanService> _logger;

        public LoanService(IUnitOfWork uow, ILoggerFactory loggerFactory)
        {
            _uow = uow;
            _logger = loggerFactory.CreateLogger<LoanService>();
        }
        
        
        public void Create(Loan loan)
        {
            var nullDate = new DateTime();
            loan.CreationDate = DateTime.UtcNow;

            if (loan.ExpDate == nullDate && loan.ExpDate > loan.CreationDate)
                throw new ArgumentException(ErrorMessages.ParameterIsRequired(nameof(loan.ExpDate)));
                        
            if(Math.Abs(loan.Percent) < 0.2)
                throw new ArgumentException(ErrorMessages.ParameterIsRequired(nameof(loan.Percent)));

            var card = _uow.Repository<Card>().GetById(loan.CardId);
            
            if (card is null)
                throw new ArgumentException(ErrorMessages.ParameterIsRequired(nameof(loan.CardId)));           
            
            _uow.Repository<Loan>().Add(loan);
            _uow.SaveChanges();
            
            _logger.LogDebug("Loan was added successfully");
        }

        public IEnumerable<Loan> GetAll(int userId)
        {
            return _uow.Repository<Loan>().GetQueryable().Where(c => c.Card.Id == userId && !c.WasReplenished);
        }

        public void Refill(Loan loan)
        {
            throw new NotImplementedException();
            
            var entity = _uow.Repository<Loan>().GetById(loan.Id);
            
            entity.WasReplenished = true;

            _uow.SaveChanges();
        }

        public IEnumerable<Loan> GetExpiredLoans(int userId)
        {
            var today = DateTime.UtcNow;
            
            return _uow.Repository<Loan>().GetQueryable()
                .Where(c => c.Card.Id == userId && !c.WasReplenished && today > c.ExpDate);
        }
    }
}