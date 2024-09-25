using Microsoft.EntityFrameworkCore;
using WebApplication5.DAL;
using WebApplication5.Interfaces;

namespace WebApplication5.Repositories
{
    //    public class NotesRepository : GenericRepository<MemoryDbContext, Note>
    //    {
    //        public NotesRepository(MemoryDbContext dbContext)
    //            : base(dbContext)
    //        {
    //        }
    public class LinksRepository<TDbContext> : IAddRepository
                    where TDbContext : DbContext
    {
            private readonly MemoryDbContext _context;

            public LinksRepository(MemoryDbContext MemoryContext)
            {
                _context = MemoryContext ?? throw new ArgumentNullException(nameof(MemoryContext));
            }




        public async Task<IEnumerable<NoteTag>> BindNote(int noteId, IEnumerable<int> tagsIds)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(x => x.Id == noteId);
            if (note == null)
                return null;

            List<NoteTag> noteTagsList = new();
            foreach (var id in tagsIds)
            {
                var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
                if (tag == null)
                    return null;

                var noteTag = new NoteTag()
                {
                    Note = note,
                    Tag = tag
                };
                noteTagsList.Add(noteTag);
            }
            await _context.NoteTag.AddRangeAsync(noteTagsList);
            await _context.SaveChangesAsync();
            return noteTagsList;
        }




        public async Task<IEnumerable<ReminderTag>?> BindReminder(int reminderId, IEnumerable<int> tagsIds)
        {
            var reminder = await _context.Reminders.FirstOrDefaultAsync(x => x.Id == reminderId);
            if (reminder == null)
                return null;

            List<ReminderTag> reminderTagsList = new();
            foreach (var id in tagsIds)
            {
                var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
                if (tag == null)
                    return null;

                var reminderTag = new ReminderTag()
                {
                    Reminder = reminder,
                    Tag = tag
                };

                reminderTagsList.Add(reminderTag);
            }

            await _context.ReminderTag.AddRangeAsync(reminderTagsList);
            await _context.SaveChangesAsync();
            return reminderTagsList;
        }




        public async Task<object> BindTag(int tagId, IEnumerable<int> noteIds, IEnumerable<int> reminderIds)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == tagId);
            if (tag == null)
                return null;

            List<NoteTag> noteTagsList = new();
            foreach (var id in noteIds)
            {
                var note = await _context.Notes.FirstOrDefaultAsync(x => x.Id == id);
                if (note == null)
                    return null;

                var noteTag = new NoteTag()
                {
                    Note = note,
                    Tag = tag
                };
                noteTagsList.Add(noteTag);
            }
            await _context.NoteTag.AddRangeAsync(noteTagsList);
            await _context.SaveChangesAsync();

            List<ReminderTag> reminderTagsList = new();
            foreach (var id in reminderIds)
            {
                var reminder = await _context.Reminders.FirstOrDefaultAsync(x => x.Id == id);
                if (reminder == null)
                    return null;

                var reminderTag = new ReminderTag()
                {
                    Reminder = reminder,
                    Tag = tag
                };

                reminderTagsList.Add(reminderTag);
            }

            await _context.ReminderTag.AddRangeAsync(reminderTagsList);
            await _context.SaveChangesAsync();


            return tag;
        }
    }
}
