using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DAL.Models
{
    public class Deposit : Entity
    {
        public string CreationDate { get; set; }

        public string Money { get; set; }

        public string EndAt { get; set; }

        public double PercentPerMonth { get; set; }

        public int? ClientId { get; set; }
        public Client Client { get; set; }
    }
}
