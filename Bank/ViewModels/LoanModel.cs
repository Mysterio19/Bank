using System;
using System.Collections.Generic;
using Bank.DAL.Models;
using Bank.Web.Resources;

namespace Bank.Web.ViewModels
{
    public class LoanModel
    {
        public LoanModel()
        {
            Cards = new List<Card>();
        }
        
        public int Id { get; set; }
        public decimal Money { get; set; }

        public decimal Percent { get; set; }

        public string ExpDate { get; set; }

        public string CreationDate { get; set; }

        public int? CardId { get; set; }

        public ICollection<Card> Cards { get; set; }

        public static LoanModel From(Loan entity)
        {
            return new LoanModel
            {
                Id = entity.Id,
                Money = entity.Money,
                Percent = entity.Percent,
                ExpDate = entity.ExpDate.ToString(CommonResources.DateFormat),
                CreationDate = entity.CreationDate.ToString(CommonResources.DateFormat),
                CardId = entity.CardId
            };
        }
        
        
        public Loan To()
        {
            return new Loan
            {
                Id = Id,
                Money = Money,
                Percent = Percent,
                CardId = CardId,
                ExpDate = ExpDate == null ? default(DateTime): CommonResources.ParseDate(ExpDate)
            };
        }
        
    }
}