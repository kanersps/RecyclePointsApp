using Microsoft.EntityFrameworkCore;
using RecyclePoints.Core.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecyclePoints.Core.Database
{
    public class RContext : DbContext 
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Auth> Auth { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=RecyclePoints.db");
        }
    }
}
