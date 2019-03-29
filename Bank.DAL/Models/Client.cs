using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DAL.Models
{
    public class Client : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string INN { get; set; }

        public bool IsBlocked { get; set; }

        public bool IsCompany { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}
