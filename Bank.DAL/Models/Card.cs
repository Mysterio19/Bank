using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DAL.Models
{
    public class Card  : Entity
    {
        public Card()
        {
            Deposits = new List<Deposit>();
        }

        public string Name { get; set; }
        
        public double CashbackPercent { get; set; }

        public string Number { get; set; }

        public DateTime ExpDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string CVV2 { get; set; }

        public decimal Money { get; set; }

        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
        
        public virtual ICollection<Deposit> Deposits { get; set; }
    }
}
