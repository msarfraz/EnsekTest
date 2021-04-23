using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsekWebApi.Data
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeterReading>()
                .HasKey(c => new { c.MeterReadingDate, c.AccountId });

            DBInitializer.Initialize(modelBuilder);
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<MeterReading> MeterReadings { get; set; }
    }
}
