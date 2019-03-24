using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DAL.Models
{
    public class Comment  : Entity
    {
        public string Header { get; set; }
        public string Description { get; set;  }

        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
