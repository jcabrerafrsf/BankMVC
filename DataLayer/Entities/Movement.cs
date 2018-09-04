using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Movement
    {

        public Guid Id { get; protected set; }

        public decimal Amount { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public virtual Guid AccountId { get; set; }

        public virtual Account Account { get; set; }

    }
}
