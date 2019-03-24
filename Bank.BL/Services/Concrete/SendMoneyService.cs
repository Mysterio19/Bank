using Bank.BL.Services.Abstract;
using Bank.DAL.Models;
using Bank.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System;
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

        public bool SendMoney(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
