using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DAL.Models
{
    public class Loan
    {
        public int Id { get; set; }

        public double Money { get; set; }

        public double Percent { get; set; }

        public string ExpDate { get; set; }

        public string CreationDate { get; set; }

        //ClientId
    }
}
