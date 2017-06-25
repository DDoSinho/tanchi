using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace tanchi.dal.Entities
{
    public class User : IdentityUser
    {
        //Father class already have fields: Id, PhoneNumber, Email, UserName, Password(hash) 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Rating { get; set; }

        public Address Address { get; set; }

    }
}
