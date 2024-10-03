using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.DAL
{
    public class NoteTag
    {
        public int NoteId { get; set; }

        [ForeignKey("NoteId")]
        public Note Note { get; set; } = null!;

        public int TagId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; } = null!;
    }
}
