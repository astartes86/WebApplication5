using WebApplication5.DAL;

namespace WebApplication5.Interfaces
{
    public interface IaddMethod
    {
        Task<IEnumerable<NoteTag>> Bind(int noteId, IEnumerable<int> tagsIds);
    }
}
