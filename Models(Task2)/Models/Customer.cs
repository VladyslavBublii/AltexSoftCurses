using System;

namespace Core.Models
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public User User { set; get; }
    }
}
