using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    class CustomerMap : EntityTypeConfiguration<Customer>
    {

        public CustomerMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(p => p.DNI)
                .IsRequired();

            this.Property(p => p.Address)
                .HasMaxLength(85)
                .IsRequired();

            this.Property(p => p.Phone)
                .HasMaxLength(25)
                .IsRequired();

            this.Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();

            this.HasRequired(p => p.Bank)
                .WithMany(p => p.Customers)
                .HasForeignKey(p => p.BankId);

        }

    }
}
