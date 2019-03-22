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
        
        public double CashbackPrecent { get; set; }

        public int Number { get; set; }

        public string ExpDate { get; set; }

        public string CreationDate { get; set; }

        public int CVV2 { get; set; }

        public decimal Money { get; set; }

        public int? ClientId { get; set; }
        public Client Client { get; set; }
        
        public virtual ICollection<Deposit> Deposits { get; set; }
    }
}
