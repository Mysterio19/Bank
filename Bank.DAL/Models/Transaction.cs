using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DAL.Models
{
    public class Transaction
    {
        public int Id { get; set; }

      //  public int ReceiverId { get; set; }

      //  public int SenderId { get; set; }

        public double Money { get; set; }

       // public int CommentId { get; set; }
    }
}
