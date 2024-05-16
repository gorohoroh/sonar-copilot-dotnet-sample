using Microsoft.EntityFrameworkCore;
using OdeToFood.Models;

namespace OdeToFood.Data;

public class OdeToFoodDbContext : DbContext
{
    public OdeToFoodDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>().HasData(
            new Restaurant { Id = 1, Name = "The Italian Bistro", Cuisine = CuisineType.Italian },
            new Restaurant { Id = 2, Name = "French Delight", Cuisine = CuisineType.French },
            new Restaurant { Id = 3, Name = "Berlin's Best", Cuisine = CuisineType.German },
            new Restaurant { Id = 4, Name = "Mama Mia's", Cuisine = CuisineType.Italian },
            new Restaurant { Id = 5, Name = "The French Bakery", Cuisine = CuisineType.French },
            new Restaurant { Id = 6, Name = "German Goodness", Cuisine = CuisineType.German },
            new Restaurant { Id = 7, Name = "Pasta Paradise", Cuisine = CuisineType.Italian },
            new Restaurant { Id = 8, Name = "Parisian Pleasures", Cuisine = CuisineType.French },
            new Restaurant { Id = 9, Name = "Frankfurt Flavors", Cuisine = CuisineType.German },
            new Restaurant { Id = 10, Name = "Venetian Vittles", Cuisine = CuisineType.Italian }
        );
    }
    
}
