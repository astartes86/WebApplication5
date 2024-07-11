using WebApplication5.Interfaces;

namespace WebApplication5.DAL
{
    public class Note : IEntity
    {
        public int Id => throw new NotImplementedException();

        public string Header { get; set; } = string.Empty;

        public string Text { get; set; }

        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();


    }
}
