
using System;
using System.Collections.Generic;
using System.Linq;
using Bank.BL.Services.Concrete;
using Bank.DAL;
using Bank.DAL.Models;
using Bank.DAL.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace Bank.Tests
{
    public class DepositServiceTests
    {
        
        
        public DepositServiceTests()
        {
            
        }
        
        [Fact]
        public void should_add_deposit_to_user_if_he_has_enough_money()
        {
            var db = new List<Deposit>();
            
            var availableCard = new Card() {Id = 1, Money = 1000m};
            
            var context = new Mock<BankDbContext>(false);
            var rep = new Mock<ICardRepository>();
            var depositRep = new Mock<IRepository<Deposit>>();
            
            var l = new List<Card>(new []{availableCard});
            rep.Setup(c => c.GetById(It.IsAny<int>())).Returns(availableCard);
            
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(c => c.CardRepository).Returns(rep.Object);
            uow.Setup(c => c.Repository<Deposit>()).Returns(depositRep.Object);

            depositRep.Setup(c => c.Add(It.IsAny<Deposit>())).Callback((Deposit d) => db.Add(d));
            
            var sut = new DepositService(uow.Object, new LoggerFactory());

            var deposit = new Deposit
            {
                Card = availableCard,
                Money = 500,
                CreationDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(6),
                CardId = 1,
                PercentPerMonth = 12
            };
            
            sut.Create(1 , deposit);
            
            db.Count.ShouldBe(1);
        }

        [Fact]
        public void should_all_fields_are_required()
        {
            
        }
        
        [Fact]
        public void should_view_all_available_deposits()
        {
            
        }
    }
}