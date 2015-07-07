using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Addon> Addons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasKey(m => m.ProductID);
            modelBuilder.Entity<Product>().Property(n => n.ProductID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Addon>().HasKey(s => s.AddonId);
            modelBuilder.Entity<Addon>().Property(t => t.AddonId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Addon>().HasRequired(m => m.Product).WithMany(n => n.Addons).HasForeignKey(o => o.ProductID);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
