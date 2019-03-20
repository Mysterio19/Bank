using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DAL.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public int LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string INN { get; set; }

        public bool IsBlocked { get; set; }

        public bool IsCompany { get; set; }
    }
}
