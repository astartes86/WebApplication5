using Microsoft.EntityFrameworkCore;

namespace WebApplication5.DAL;

public class MemoryDbContext : DbContext
{
    public MemoryDbContext(DbContextOptions<MemoryDbContext> options): base(options)
    {
    }

    public virtual DbSet<Note> Notes { get; set; }
    public virtual DbSet<Reminder> Reminders { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<NoteTag> NoteTag { get; set; }//по умолчанию таблица миграцией  создается с именем класса данных таблицы
    public virtual DbSet<ReminderTag> ReminderTag { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<NoteTag>().HasKey(u => new { u.NoteId, u.TagId });
        modelBuilder.Entity<ReminderTag>().HasKey(u => new { u.ReminderId, u.TagId });

    }

}