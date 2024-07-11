using WebApplication5.Interfaces;

namespace WebApplication5.DAL
{
    public class Reminder : IEntity
    {
        public int Id { get; set; }

        public string Header { get; set; } = string.Empty;

        public string Text { get; set; }

        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
    }
}
