using System;
using System.ComponentModel.DataAnnotations;
using Bank.DAL.Models;
using Bank.Web.Resources;

namespace Bank.Web.ViewModels
{
    public class CardViewModel
    {
        [Required]
        public string Name { get; set; }
        
        public double CashbackPercent { get; set; }

        public decimal Number { get; set; }

        public string ExpDate { get; set; }

        public string CreationDate { get; set; }

        public int CVV2 { get; set; }

        public decimal Money { get; set; }

        public int ClientId { get; set; }

        public static CardViewModel From(Card entity)
        {
            string format = CommonResources.DateFormat;
            
            return new CardViewModel
            {
                Name = entity.Name,
                CashbackPercent = entity.CashbackPercent,
                Number = entity.Number,
                ExpDate = entity.ExpDate.ToString(format),
                CreationDate = entity.CreationDate.ToString(format),
                CVV2 = entity.CVV2,
                Money = Math.Round(entity.Money, 2),
                ClientId = entity.ClientId ?? 0
            };
        }

        public Card To(int clientId)
        {
            return new Card
            {
                Name = Name,
                ClientId = clientId,
                CashbackPercent = CashbackPercent
            };
        }
    }
} 