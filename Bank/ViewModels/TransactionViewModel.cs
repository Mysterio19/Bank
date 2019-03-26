using Bank.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Bank.Web.ViewModels
{
    public class TransactionViewModel
    {
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public double PaymentValue { get; set; }

        public static TransactionViewModel From(Transaction entity)
        {
            return new TransactionViewModel
            {
                PaymentValue = entity.Money
            };
        }

        public Transaction To(int clientId)
        {
            return new Transaction
            {
                ClientId = clientId,
                Money = PaymentValue,
            };
        }
    }
}
