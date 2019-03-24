using Bank.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Web.ViewModels
{
    public class TransactionViewModel
    {
        [Required]
        public string CardId { get; set; }

        [Required]
        public double PaymentValue { get; set; }

        public static TransactionViewModel From(Transaction entity)
        {
            return null;
            //string format = CommonResources.DateFormat;

            //return new CardViewModel
            //{
            //    Name = entity.Name,
            //    CashbackPercent = entity.CashbackPercent,
            //    Number = entity.Number,
            //    ExpDate = entity.ExpDate.ToString(format),
            //    CreationDate = entity.CreationDate.ToString(format),
            //    CVV2 = entity.CVV2,
            //    Money = Math.Round(entity.Money, 2),
            //    ClientId = entity.ClientId ?? 0
            //};
        }

        public Transaction To(int clientId)
        {
            return null;
            //return new Card
            //{
            //    Name = Name,
            //    ClientId = clientId,
            //    CashbackPercent = CashbackPercent
            //};
        }
    }
}
