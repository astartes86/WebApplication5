using Microsoft.EntityFrameworkCore;
using WebApplication5.DAL;
using WebApplication5.Interfaces;
using static WebApplication5.Repositories.NotesRepository;

namespace WebApplication5.Repositories
{
    //    public class NotesRepository : GenericRepository<MemoryDbContext, Note>
    //    {
    //        public NotesRepository(MemoryDbContext dbContext)
    //            : base(dbContext)
    //        {
    //        }
        public class NoteTagRepository<TDbContext> : IaddMethod
                    where TDbContext : DbContext
    {
            private readonly MemoryDbContext _context;

            public NoteTagRepository(MemoryDbContext MemoryContext)
            {
                _context = MemoryContext ?? throw new ArgumentNullException(nameof(MemoryContext));
            }




        public async Task<IEnumerable<NoteTag>> Bind(int noteId, IEnumerable<int> tagsIds)
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
    }
}
