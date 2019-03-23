
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Bank.BL.Services.Abstract;
using Bank.BL.Services.Concrete;
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
        private List<Deposit> _db;
        private List<Client> _clients;
        private Deposit _deposit;
        private Mock<IUnitOfWork> _uow;
        private IDepositService _sut;
        private DateTime _dateTime;

        public DepositServiceTests()
        {
            this._db = new List<Deposit>();
            _deposit = GetDeposit();
            _uow = GetUnitOfWork(_db, GetCard());
            _sut = new DepositService(_uow.Object, new LoggerFactory());
            _clients = new List<Client>();
        }
        
        [Fact]
        public void should_add_deposit_to_user_if_he_has_enough_money()
        {
            _sut.Create(_deposit);
           
            _db.Count.ShouldBe(1);
            _db.First().ShouldBeSameAs(_deposit);
            _uow.Verify();
        }

        [Fact]
        public void should_creation_date_created()
        {
            _sut.Create(_deposit);
            
            _db.Count.ShouldBe(1);
            _db.First().CreationDate.ShouldNotBe(new DateTime());
        }

        [Fact]
        public void throw_if_card_does_not_exist()
        {
            _deposit.CardId = 3;
               
            var sut = new DepositService(_uow.Object, new LoggerFactory());
            Assert.Throws<ArgumentException>(() => sut.Create(_deposit));
        }
        
        [Fact]
        public void throw_if_money_is_less_than_it_on_card()
        {
            _deposit.Money = 12000;
               
            var sut = new DepositService(_uow.Object, new LoggerFactory());
            Assert.Throws<ArgumentException>(() => sut.Create(_deposit));
        }
        
        [Fact]
        public void throw_if_end_date_is_less_than_current()
        {
            _deposit.EndDate = DateTime.UtcNow.AddDays(-1);
               
            var sut = new DepositService(_uow.Object, new LoggerFactory());
            Assert.Throws<ArgumentException>(() => sut.Create(_deposit));
        }
        
        [Fact]
        public void should_view_all_available_deposits()
        {
            _sut.ViewAllByUserId(11).Count().ShouldBe(1);
        }

        [Fact]
        public void should_user_take_money_if_it_possible()
        {
            _deposit.Money = 200;
            _sut.Create(_deposit);
            _deposit.WasTaken = true;
            
            var deposit2 = GetDeposit();
            deposit2.Id = 12;
            deposit2.Money = 300;
            _sut.Create(deposit2);

            _db[1].CreationDate = new DateTime(2018, 01, 11);
            _db[1].EndDate = new DateTime(2018, 11, 11);
            _db[1].WasTaken = false;
            _sut.TakeMoney(11);
            
            _uow.Verify(c => c.SaveChanges(), Times.Exactly(3));
            _db.Count.ShouldBe(2);
            _db[1].WasTaken.ShouldBe(true);
            Math.Round(_db[1].Card.Money, 0).ShouldBe(1331);
        }
        
        private Mock<IUnitOfWork> GetUnitOfWork(List<Deposit> db, Card card)
        {
            var repClient = new Mock<IRepository<Client>>();
            repClient.Setup(c => c.GetQueryable()).Returns(new List<Client>(new [] {GetClient()}).AsQueryable());
            
            var repCard = new Mock<IRepository<Card>>();
            repCard.Setup(c => c.GetQueryable()).Returns(new List<Card>(new [] {card}).AsQueryable());
            
            var depositRep = new Mock<IRepository<Deposit>>();
            depositRep.Setup(c => c.Add(It.IsAny<Deposit>())).Callback((Deposit d) => db.Add(d));
              
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(c => c.Repository<Card>()).Returns(repCard.Object);
            uow.Setup(c => c.Repository<Deposit>()).Returns(depositRep.Object);
            uow.Setup(c => c.Repository<Client>()).Returns(repClient.Object);
            uow.Setup(c => c.SaveChanges()).Verifiable();

            return uow;
        }
        
        private  Deposit GetDeposit()
        {
            return new Deposit
            {
                Card = GetCard(),
                Money = 500,
                EndDate = DateTime.UtcNow.AddMonths(6),
                CardId = 1,
                PercentPerMonth = 12
            };
        }

        private  Client GetClient()
        {
            var card = GetCard();
            
            var client = new Client()
            {
                Id = 11,
                Cards = new[] { card }
            };
            
            card.Client = client;
                
            return client;
        }
        
        private Card GetCard()
        {
            var deposits = _db;
            var card = new Card() {Id = 1, Money = 1000m, Deposits = deposits};
           
            for (int i = 0; i < deposits.Count; i++)
            {
                deposits[i].Card = card;
            }
            
            return card;
        }
    }
}