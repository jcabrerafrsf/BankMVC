using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    internal class MovementMap : EntityTypeConfiguration<Movement>
    {

        public MovementMap()
        {
            this.HasKey(p => p.Id);

            this.Property(p => p.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(p => p.Amount)
                .IsRequired();

            this.Property(p => p.Date)
                .IsRequired();

            this.HasRequired(p => p.Account)
                .WithMany(p => p.Movements)
                .HasForeignKey(p => p.AccountId);
        }


    }
}
