using WebApplication5.DAL;

namespace WebApplication5.Interfaces
{
    public interface IAddRepository
    {
        Task<IEnumerable<NoteTag>> BindNote(int noteId, IEnumerable<int> tagsIds);
        Task<IEnumerable<ReminderTag>?> BindReminder(int reminderId, IEnumerable<int> tagsIds);//почему ?
        Task<object> BindTag(int tagId, IEnumerable<int> noteIds, IEnumerable<int> ReminderIds);
    }
}
