using Microsoft.EntityFrameworkCore;

namespace WebApplication5.DAL;

public class MemoryDbContext : DbContext
{
    public MemoryDbContext()
    {
    }

    public MemoryDbContext(DbContextOptions<MemoryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable(nameof(Employees));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.FirstName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.LastName)
                  .IsRequired()
                  .HasMaxLength(100);
        });
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable(nameof(Departments));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
        });
    }

}