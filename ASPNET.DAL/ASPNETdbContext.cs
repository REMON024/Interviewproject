using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.DAL
{
   public class ASPNETdbContext
    {
        public ASPNETdbContext(DbContextOptions<ASPNETdbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

        }
        public virtual DbSet<Account> Account { get; set; }

    }
}
