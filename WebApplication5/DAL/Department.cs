using WebApplication5.Interfaces;

namespace WebApplication5.DAL
{
    public class Department : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}
