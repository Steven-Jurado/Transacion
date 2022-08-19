﻿
namespace Nttdata.Steven.Jurado.Repository.Sql.Context
{
    using Microsoft.EntityFrameworkCore;
    using Nttdata.Steven.Jurado.Domain.Entities;

    public class TransactionContext : DbContext
    {

        public TransactionContext()
        {

        }

        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"));
                optionsBuilder.UseSqlServer("Server=localhost;Database=nttdata;Trusted_Connection=True;");
            }
        }


    }
}
