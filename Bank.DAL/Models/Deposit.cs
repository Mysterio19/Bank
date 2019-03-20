using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DAL.Models
{
    public class Deposit
    {
        public int Id { get; set; }

        public string CreationDate { get; set; }

        public string Money { get; set; }

        public string EndAt { get; set; }

        public double PercentPerMonth { get; set; }

        // ClientId
    }
}
