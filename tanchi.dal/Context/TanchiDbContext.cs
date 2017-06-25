using DAL.Model.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class TanchiDbContext : IdentityDbContext<User>
    {
        public TanchiDbContext(DbContextOptions<TanchiDbContext> options) : base(options)
        {

        }


    }
}
