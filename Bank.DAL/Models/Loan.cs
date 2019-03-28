using System;
using System.Collections.Generic;
using System.Text;
using Bank.DAL.Abstract;

namespace Bank.DAL.Models
{
    public class Loan : Entity, IFormulaEntity
    {
        public decimal Money { get; set; }

        public decimal Percent { get; set; }

        public DateTime ExpDate { get; set; }
        public DateTime CreationDate { get; set; }

        public bool WasReplenished { get; set; }

        public virtual Card Card { get; set; }
        public int? CardId { get; set; }

        public void RefillCredit(decimal calculatedMoney)
        {
            if (calculatedMoney > Card.Money)
            {
                throw new ArgumentException("Cannot refill loan because you have not enough money");
            }
            
            Card.Money -= calculatedMoney;
            WasReplenished = true;
        }
    }
}
