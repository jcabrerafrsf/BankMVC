using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Customer
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int DNI { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public Guid BankId { get; set; }

        public CustomerType CustomerType { get; set; }

        public virtual Bank Bank { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

    }
}
