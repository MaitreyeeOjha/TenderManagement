using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Data
{
    public class TenderDbContext : DbContext
    {
        public TenderDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Tender> Tenders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData
              (new User {UserId = 1, UserName = "User1", FirstName="Test User", LastName="User 1",Password="Password1" },
              new User { UserId=2, UserName = "User2", FirstName = "Test User", LastName = "User 2", Password = "Password2" });

            modelBuilder.Entity<Tender>().HasData
                (new Tender() { TenderId=1, Title="Title 1", ReferenceNumber="T1",Description="Test Tender",ReleaseDate=DateTime.Now,ClosingDate=DateTime.Now.AddDays(2)});
        }
    }
}
