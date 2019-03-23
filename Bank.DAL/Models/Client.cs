using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DAL.Models
{
    public class Client : Entity
    {
        public Client()
        {
            Cards = new List<Card>();
            Comments = new List<Comment>();
            Loans = new List<Loan>();
            Notifications = new List<Notification>();
            Transactions = new List<Transaction>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string INN { get; set; }

        public bool IsBlocked { get; set; }

        public bool IsCompany { get; set; }

        public ICollection<Card> Cards { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Loan> Loans { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}
