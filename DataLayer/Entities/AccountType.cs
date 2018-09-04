using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class AccountType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal MaxDeposit { get; set; }

        public decimal MaxExtracion { get; set; }

        public decimal MaxTransfer { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }

}
