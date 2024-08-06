using Microsoft.EntityFrameworkCore;
using WebApplication5.Interfaces;

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
    public virtual DbSet<Note> Notes { get; set; }
    public virtual DbSet<Reminder> Reminders { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
<<<<<<< HEAD
        modelBuilder.Entity<NoteTag>().HasKey(u => new { u.NoteId, u.TagId });
        modelBuilder.Entity<ReminderTag>().HasKey(u => new { u.ReminderId, u.TagId });
=======
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

        modelBuilder.Entity<Note>(entity =>
        {
            entity.ToTable(nameof(Note));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Header)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(e => e.Text)
                  .IsRequired()
                  .HasMaxLength(200);
        });

        modelBuilder.Entity<Reminder>(entity =>
        {
            entity.ToTable(nameof(Reminder));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Header)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(e => e.Text)
                  .IsRequired()
                  .HasMaxLength(200);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable(nameof(Tag));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(200);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable(nameof(Departments));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
        });
>>>>>>> 9731f92 (добавил свои сущности, протестил их свагером. остается удалить исходные. или мож оставлю пока.)
    }

}