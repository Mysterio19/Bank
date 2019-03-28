using System;
using Bank.DAL.Abstract;

namespace Bank.BL.Providers
{
    public class MonthProvider : IMonthProvider
    {
        public int GetRangeMonths(IRangeEntity entity)
        {
            return (int) (entity.ExpDate - entity.CreationDate).TotalDays / 30;
        }
    }
}