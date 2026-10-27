using Microsoft.EntityFrameworkCore;
using AutoCollection.Models;

public class AutoCollectionContext(DbContextOptions<AutoCollectionContext> options) : DbContext(options)
{
    public DbSet<AutoCollection.Models.Automobile> Automobile { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Automobile>().HasData(
            new Automobile
            {
                Id = 1,
                Make = "Ford",
                Model = "Mustang",
                Year = 1967
            },
            new Automobile
            {
                Id = 2,
                Make = "Pontiac",
                Model = "GTO",
                Year = 1970
            },
            new Automobile
            {
                Id = 3,
                Make = "Shelby",
                Model = "Cobra",
                Year = 1965
            },
            new Automobile
            {
                Id = 4,
                Make = "Nissan",
                Model = "Skyline R34",
                Year = 1998
            }
            );
    }
}
