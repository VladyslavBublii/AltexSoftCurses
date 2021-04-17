using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public IEnumerable<Guid> ProductsId { get; set; } 

        public decimal TotalPrice { get; set; }

        public DateTime OrderTime { get; set; }
    }
}
