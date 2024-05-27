using WebApplication5.Interfaces;

namespace WebApplication5.DAL
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
}
