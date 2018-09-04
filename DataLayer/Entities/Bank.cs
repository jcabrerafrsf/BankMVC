using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Bank
    {

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

    }
}
