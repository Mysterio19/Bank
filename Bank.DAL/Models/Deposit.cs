using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DAL.Models
{
    public class Deposit : Entity
    {
        public DateTime CreationDate { get; set; }

        public decimal Money { get; set; }

        public DateTime EndDate { get; set; }

        public double PercentPerMonth { get; set; }

        public int? CardId { get; set; }
        public Card Card { get; set; }
    }
}
