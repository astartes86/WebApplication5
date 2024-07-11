using System.ComponentModel.DataAnnotations;
using WebApplication5.Interfaces;

namespace WebApplication5.DAL
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public int? DepartmentId { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        //public Department? Department { get; set; }
    }
}
