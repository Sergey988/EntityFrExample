using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrExample2
{
    class MyDbContext
    {
        public class MyDbContext : DbContext
        {
            //public MyDbContext()
            //{
            //    this.Database.EnsureCreated();
            //}
            //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //{
            //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDb;Trusted_Connection=True;");
            //    base.OnConfiguring(optionsBuilder);
            //}

            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{

            //}
        }
    }
}
