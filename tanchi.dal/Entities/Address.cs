using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tanchi.dal.Entities
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        public int ZipCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }
    }
}
