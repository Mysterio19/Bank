using System;
using Bank.DAL.Abstract;

namespace Bank.BL.Providers
{
    public interface IMonthProvider
    {
        int GetRangeMonths(IRangeEntity entity);
    }
}