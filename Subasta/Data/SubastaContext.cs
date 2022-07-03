using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Subasta.Models;

namespace Subasta.Data
{
    public class SubastaContext : DbContext
    {
        public SubastaContext (DbContextOptions<SubastaContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Item { get; set; }
        public DbSet<Puja> Puja { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Puja>().ToTable("Puja");
        }
    }
}
