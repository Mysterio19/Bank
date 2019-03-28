using Bank.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace Bank.DAL
{
    public class BankDbContext : DbContext
    {
        private static bool _created = false;

        public BankDbContext(DbContextOptions options) : base(options)
        {}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Bank.db");
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Deposit> Deposits { get; set; }

        public DbSet<Loan> Loans { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
