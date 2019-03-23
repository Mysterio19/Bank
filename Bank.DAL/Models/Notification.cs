using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DAL.Models
{
    public class Notification : Entity
    {
        public string Subject { get; set; }

        public string Description { get; set; }

        public int? ClientId { get; set; }
        public Client Client { get; set; }
    }
}
