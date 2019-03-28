using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DAL.Models
{
    public class Loan : Entity
    {
        public double Money { get; set; }

        public double Percent { get; set; }

        public DateTime ExpDate { get; set; }
        public DateTime CreationDate { get; set; }

        public bool WasReplenished { get; set; }

        public Card Card { get; set; }
        public int? CardId { get; set; }
    }
}
