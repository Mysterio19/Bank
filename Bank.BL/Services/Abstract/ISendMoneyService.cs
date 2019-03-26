using Bank.DAL.Models;
using System.Transactions;
using Transaction = Bank.DAL.Models.Transaction;

namespace Bank.BL.Services.Abstract
{
    public interface ISendMoneyService
    {
        void SendMoney(Transaction transaction);

        Client GetClientByCardNumber(string cardNumber);
    }
}
