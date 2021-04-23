using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsekWebApi.Data
{
    public class DBInitializer
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=2344,FirstName="Tommy", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=2233,FirstName="Barry", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=8766,FirstName="Sally", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=2345,FirstName="Jerry", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=2346,FirstName="Ollie", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=2347,FirstName="Tara", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=2348,FirstName="Tammy", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=2349,FirstName="Simon", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=2350,FirstName="Colin", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=2351,FirstName="Gladys", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=2352,FirstName="Greg", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=2353,FirstName="Tony", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=2355,FirstName="Arthur", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=2356,FirstName="Craig", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=6776,FirstName="Laura", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=4534,FirstName="JOSH", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=1234,FirstName="Freya", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=1239,FirstName="Noddy", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=1240,FirstName="Archie", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=1241,FirstName="Lara", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=1242,FirstName="Tim", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=1243,FirstName="Graham", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=1244,FirstName="Tony", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=1245,FirstName="Neville", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=1246,FirstName="Jo", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=1247,FirstName="Jim", LastName="Test" });
            modelBuilder.Entity<Account>().HasData(new Account{AccountId=1248,FirstName="Pam", LastName="Test" });
        
        }
    }
}
