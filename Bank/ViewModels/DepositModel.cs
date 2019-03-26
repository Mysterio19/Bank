using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bank.DAL.Models;
using Bank.Web.Resources;

namespace Bank.Web.ViewModels
{
    public class DepositModel
    {
        public DepositModel()
        {
            Cards = new List<Card>();
        }
        
        public string CreationDate { get; set; }

        [Required]
        public decimal Money { get; set; }

        public string EndDate { get; set; }

        [Required]
        public decimal PercentPerMonth { get; set; }

        public int? CardId { get; set; }
        
        public IList<Card> Cards { get; set; }

        public static DepositModel From(Deposit deposit)
        {
            var format = CommonResources.DateFormat;

            return new DepositModel
            {
                CreationDate = deposit.CreationDate.ToString(format),
                EndDate = deposit.EndDate.ToString(format),
                Money = deposit.Money,
                CardId = deposit.CardId,
                PercentPerMonth = deposit.PercentPerMonth
            };
        }

        public Deposit To()
        {
            return new Deposit
            {
                Money = Money,
                PercentPerMonth = PercentPerMonth,
                CardId = CardId
            };
        }
    }
}