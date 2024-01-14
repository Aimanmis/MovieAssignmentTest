// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using MovieAssignmentTest.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<MovieModel> MovieModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Add any additional model configurations here

        modelBuilder.Entity<MovieModel>()
            .Property(m => m.CreatedAt)
            .HasColumnType("datetime2") // Adjust the type if needed
            .HasDefaultValueSql("getdate()"); // Optional: set a default value

        modelBuilder.Entity<MovieModel>()
            .Property(m => m.UpdatedAt)
            .HasColumnType("datetime2") // Adjust the type if needed
            .HasDefaultValueSql("getdate()"); // Optional: set a default value
    }
}
