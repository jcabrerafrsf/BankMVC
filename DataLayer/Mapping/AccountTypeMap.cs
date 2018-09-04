using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    internal class AccountTypeMap : EntityTypeConfiguration<AccountType>
    {

        public AccountTypeMap()
        {
            this.HasKey(p => p.Id);

            this.Property(p => p.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(p => p.Name)
                .HasMaxLength(20)
                .IsRequired();

            this.Property(p => p.MaxDeposit)
                .IsRequired();

            this.Property(p => p.MaxExtracion)
                .IsRequired();

            this.Property(p => p.MaxTransfer)
                .IsRequired();
        }

    }
}
