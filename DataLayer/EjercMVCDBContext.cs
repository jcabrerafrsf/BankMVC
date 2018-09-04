using DataLayer.Entities;
using DataLayer.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EjercMVCDBContext : DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }


        public EjercMVCDBContext() : base("name=defaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new BankMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new MovementMap());
            modelBuilder.Configurations.Add(new AccountTypeMap());
        }
    }
}
