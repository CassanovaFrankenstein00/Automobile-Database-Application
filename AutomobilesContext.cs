using Microsoft.EntityFrameworkCore;

public class AutomobilesContext(DbContextOptions<AutomobilesContext> options) : DbContext(options)
{
    public DbSet<Automobiles.Models.Vehicles> Vehicles { get; set; } = default!;
}
