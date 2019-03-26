using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CardServiceTests
    {
        private ICardService _sut;
        private List<Card> _db;
        private Mock<IUnitOfWork> uow;

        public CardServiceTests()
        {
            uow = GetUnitOfWork();
            var logger = new LoggerFactory();
           
            
            _sut = new CardService(uow.Object, logger);
            _db = new List<Card>();
        }

        [Fact]
        public void should_card_add_correctly_to_db()
        {
            var card = GetClient().Cards.ElementAt(0);
            _sut.Create(card);

            uow.Verify();
        }

        [Fact]
        public void should_card_creation_date_be_present()
        { 
            var card = GetClient().Cards.ElementAt(0);
            _sut.Create(card);

            var el = _db.ElementAt(0);
            el.CreationDate.Year.ShouldBe(DateTime.UtcNow.Year);
        }

        [Fact]
        public void should_card_exp_date_be_3_years_ahead()
        {
            var card = GetClient().Cards.ElementAt(0);
            _sut.Create(card);

            var el = _db.ElementAt(0);
            el.ExpDate.Year.ShouldBe(DateTime.UtcNow.AddYears(3).Year);
        }
        
        [Fact]
        public void should_card_money_be_0()
        {
            var card = GetClient().Cards.ElementAt(0);
            _sut.Create(card);

            var el = _db.ElementAt(0);
            el.Money.ShouldBe(0);
        }

        [Fact]
        public void should_card_cvv2_length_be_4()
        {
            var card = GetClient().Cards.ElementAt(0);
            _sut.Create(card);

            var el = _db.ElementAt(0);
            el.CVV2.Length.ShouldBe(4);
        }
        
        [Fact]
        public void should_card_number_length_be_16()
        {
            var card = GetClient().Cards.ElementAt(0);
            _sut.Create(card);

            var el = _db.ElementAt(0);
            el.Number.Length.ShouldBe(16);
        }
        
        
        [Fact]
        public void should_throw_if_card_name_is_null()
        {
            var card = GetClient().Cards.ElementAt(0);
            card.Name = "";
            Assert.Throws<ArgumentException>(() => _sut.Create(card));
        }
        
        [Fact]
        public void should_throw_if_CashbackPercent_is_empty()
        {
            var card = GetClient().Cards.ElementAt(0);
            card.CashbackPercent = 0;
            Assert.Throws<ArgumentException>(() => _sut.Create(card));
        }

        [Fact]
        public void should_throw_if_client_did_not_find()
        {
            var card = GetClient().Cards.ElementAt(0);
            card.ClientId = 11;
            Assert.Throws<ArgumentException>(() => _sut.Create(card));
        }

        private Mock<IUnitOfWork> GetUnitOfWork()
        {
            var repClient = new Mock<IRepository<Client>>();
            repClient.Setup(c => c.GetQueryable()).Returns(new List<Client>(new [] {GetClient()}).AsQueryable());

            var cardRep = new Mock<IRepository<Card>>();
            cardRep.Setup(c => c.Add(It.IsAny<Card>())).Callback((Card d) => _db.Add(d));
              
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(c => c.Repository<Card>()).Returns(cardRep.Object);
            uow.Setup(c => c.Repository<Client>()).Returns(repClient.Object);
            uow.Setup(c => c.SaveChanges()).Verifiable();

            return uow;
        }
        
        private Card GetCard()
        {
            var card = new Card() {Id = 1, Money = 1000m, CashbackPercent = 12, ClientId = 1, Name = "Personal card"};
            return card;
        }
        
        private Client GetClient()
        {
            var card = GetCard();
            
            var client = new Client()
            {
                Id = 1,
                Cards = new[] { card }
            };
            
            card.Client = client;
                
            return client;
        }
        
    }
}