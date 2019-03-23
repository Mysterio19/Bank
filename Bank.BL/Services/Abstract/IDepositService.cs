using System.Collections;
using System.Collections.Generic;
using Bank.DAL.Models;

namespace Bank.BL.Services.Abstract
{
    public interface IDepositService
    {
        void Create(Deposit deposit);       
        IEnumerable<Deposit> ViewAllByUserId(int userId);
        void TakeMoney(int userId);
    }
}