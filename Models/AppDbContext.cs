using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam2.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Cake> Cakes { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    Name = "ABC"
                },
                new Category()
                {
                    CategoryId = 2,
                    Name = "DEF"
                },
                new Category()
                {
                    CategoryId = 3,
                    Name = "GHI"
                },
                new Category()
                {
                    CategoryId = 4,
                    Name = "JKL"
                },
                new Category()
                {
                    CategoryId = 5,
                    Name = "MNO"
                });
            modelBuilder.Entity<Cake>().HasData(
                new Cake()
                {
                    CakeId = 1,
                    CategoryId = 1,
                    Ingredient = "Bột mì, sữa",
                    IsDeleted = false,
                    ManufacturingDate = DateTime.Parse("22/02/2020"),
                    ExpiryDate = DateTime.Parse("22/07/2020"),
                    Name = "Bánh ngọt",
                    Price = 5000
                },
                new Cake()
                {
                    CakeId = 2,
                    CategoryId = 2,
                    Ingredient = "Bột mì, muối",
                    IsDeleted = false,
                    ManufacturingDate = DateTime.Parse("22/03/2020"),
                    ExpiryDate = DateTime.Parse("22/08/2020"),
                    Name = "Bánh mặn",
                    Price = 10000
                },
                new Cake()
                {
                    CakeId = 3,
                    CategoryId = 3,
                    Ingredient = "Bột mì, trứng",
                    IsDeleted = false,
                    ManufacturingDate = DateTime.Parse("22/04/2020"),
                    ExpiryDate = DateTime.Parse("22/09/2020"),
                    Name = "Bánh kem",
                    Price = 20000
                });
        }
    }
}
