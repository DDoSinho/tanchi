using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model.Identity
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int ZipCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }
    }
}
