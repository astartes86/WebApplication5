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

        modelBuilder.Entity<NoteTag>().HasKey(u => new { u.NoteId, u.TagId });
        modelBuilder.Entity<ReminderTag>().HasKey(u => new { u.ReminderId, u.TagId });


    }

}