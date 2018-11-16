using cortanarecipes.Helpers;
using cortanarecipes.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;


namespace cortanarecipes.DataAccess
{
    public class ApplicationContext : DbContext
    {
        
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Instruction> Instructions { get; set; }

        public ApplicationContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>().HasKey(t => t.Id);
            modelBuilder.Entity<Ingredient>().HasKey(t => t.Id);
            modelBuilder.Entity<Instruction>().HasKey(t => t.Id);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var dbPath = DependencyService.Get<IDBPath>().GetDbPath();
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
