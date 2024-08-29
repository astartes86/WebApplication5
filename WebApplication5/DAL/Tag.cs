using WebApplication5.Interfaces;

namespace WebApplication5.DAL
{
    public class Tag : IEntity
    {   
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        //public IEnumerable<NoteTag> NoteTags { get; set; } = new List<NoteTag>();

    }
}
