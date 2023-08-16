using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDemoOne.Models;

namespace WebAPIDemoOne.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Shirt> Shirts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //I can override names of Shirt props here
            //In this code first sql  approach, the props of my shirt class will be the table columns
            //entity framework automatically makes the id prop the primary key

            //when we create additional tables, we will also specifiy the relationship between the tables here

            //data seeding

            modelBuilder.Entity<Shirt>().HasData(
                new Shirt { ShirtId = 1, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 30, Size = 10 },
                new Shirt { ShirtId = 2, Brand = "Your Brand", Color = "Red", Gender = "Men", Price = 20, Size = 12 },
                new Shirt { ShirtId = 3, Brand = "The best", Color = "Yellow", Gender = "Women", Price = 60, Size = 8 }
            );
        }
    }
}
