using System.Collections;
using System.Collections.Generic;
using Bank.DAL.Models;

namespace Bank.BL.Services.Abstract
{
    public interface IDepositService
    {
        void Create(int userId, Deposit deposit);       
        IEnumerable<Deposit> ViewAllByUserId(int userId);
    }
}