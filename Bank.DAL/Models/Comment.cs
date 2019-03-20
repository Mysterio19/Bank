﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set;  }

        public int? ClientId { get; set; }
        public Client Client { get; set; }
    }
}
