using Bank.DAL.Models;
using System.Transactions;
using Transaction = Bank.DAL.Models.Transaction;

namespace Bank.BL.Services.Abstract
{
    public interface ISendMoneyService
    {
        bool SendMoney(Transaction transaction);
    }
}
