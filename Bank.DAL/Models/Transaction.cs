using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank.DAL.Models
{
    public class Transaction : Entity
    {
        public double Money { get; set; }

        public string Comment { get; set; }

        public int? ClientId { get; set; }
        public Client Receiver { get; set; }
    }
}
