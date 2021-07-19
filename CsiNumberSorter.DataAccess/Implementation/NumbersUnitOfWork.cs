using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CsiNumberSorter.Domain;

namespace CsiNumberSorter.DataAccess.Implementation
{
    public class NumbersUnitOfWork : DbContext
    {
        public NumbersUnitOfWork(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SortedNumbers> SortedNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SortedNumbers>().ToTable("SortedNumbers");
        }

    }
}
