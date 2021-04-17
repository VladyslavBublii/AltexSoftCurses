using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Cart
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public IEnumerable<Guid> ProductsId { get; set; }
    }
}
