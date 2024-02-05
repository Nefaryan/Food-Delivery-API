using FoodDataLayer.Models;
using FoodDataLayer.Models.Food;
using FoodDataLayer.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDataLayer.DataContext
{
    public class FoodDBContext : DbContext
    {
        public FoodDBContext(DbContextOptions<FoodDBContext>options)
        :base(options){ }

        public DbSet<User> Users { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ingredient>()
           .Property(i => i.NutritionalVelue)
           .HasPrecision(18, 2); 

            modelBuilder.Entity<Ingredient>()
                .Property(i => i.GramsOfProtein)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Ingredient>()
                .Property(i => i.GramsOfCarboidrate)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Ingredient>()
                .Property(i => i.GramasOfFat)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.PreparationTime)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<User>().HasIndex(u => u.FiscalCode).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }
    }
}
