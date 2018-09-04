using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    internal class AccountMap : EntityTypeConfiguration<Account>
    {

        public AccountMap()
        {
            this.HasKey(p => p.Id);

            this.Property(p => p.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.HasRequired(p => p.Customer)
                .WithMany(p => p.Accounts)
                .HasForeignKey(p => p.CustomerId);

            this.HasRequired(p => p.AccountType)
                .WithMany(p => p.Accounts)
                .HasForeignKey(p => p.AccountTypeId);
        }

    }
}
