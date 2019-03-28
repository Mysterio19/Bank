using System;
using Bank.DAL.Abstract;

namespace Bank.BL.Providers
{
    public class PercentFormula : IFormulaProvider
    {
        private readonly IMonthProvider _monthProvider;
        
        public PercentFormula(IMonthProvider monthProvider)
        {
            _monthProvider = monthProvider;
        }

        public decimal GetResult(IFormulaEntity entity)
        {
            return (decimal)((double)entity.Money * Math.Pow((double)(1 + entity.Percent / 100 * 30  / 365 ), 
                                 _monthProvider.GetRangeMonths(entity)));
        }
            
    }
}