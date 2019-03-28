using System.Collections;
using System.Collections.Generic;
using Bank.DAL.Models;

namespace Bank.BL.Services.Abstract
{
    public interface ILoanService
    {
        void Create(Loan loan);

        IEnumerable<Loan> GetAll(int userId);

        void Refill(Loan loan);

        IEnumerable<Loan> GetExpiredLoans(int userId);
    }
}