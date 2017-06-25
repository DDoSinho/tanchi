using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tanchi.dal.Entities
{
    public class Consultation
    {
        [Key]
        public Guid Id { get; set; }

        public User Teacher { get; set; }

        public ICollection<User> Students { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int MaxPerson { get; set; }

        public Decimal Price { get; set; }

        public Double PriceQuantity { get; set; }

        public String Comment { get; set; }

        public Address Address { get; set; }

        public Subject Subject { get; set; }
    }
}
