using System.ComponentModel.DataAnnotations;
using WebApplication5.Interfaces;

namespace WebApplication5.DAL
{
    public class Note : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Header { get; set; } = string.Empty;
        [Required]
        public string Text { get; set; } = string.Empty;

<<<<<<< HEAD
        public IEnumerable<NoteTag> NoteTags { get; set; } = new List<NoteTag>();
=======
        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
>>>>>>> 9731f92 (добавил свои сущности, протестил их свагером. остается удалить исходные. или мож оставлю пока.)


    }
}
