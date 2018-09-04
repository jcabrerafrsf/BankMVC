using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Account
    {

        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Guid AccountTypeId { get; set; }

        [Required]
        public decimal Credit { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual AccountType AccountType { get; set; }
        
        public virtual ICollection<Movement> Movements { get; set; }

    }
}
