using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using tanchi.dal.Entities;

namespace tanchi.dal.Context
{
    public class TanchiDbContext : IdentityDbContext<User>
    {
        public TanchiDbContext(DbContextOptions<TanchiDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Consultation> Consultation { get; set; }
        public DbSet<PrivateLesson> PrivateLesson { get; set; }
        public DbSet<Subject> Subject { get; set; }





    }
}
