

using Microsoft.AspNetCore.Mvc;
using WebApplication5.DAL;
using WebApplication5.Interfaces;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("/api/1.0/[controller]")]
    public class EmployeesController : GenericApiController<Employee>
    {
        public EmployeesController(IRepository<Employee> repository) : base(repository)
        {
        }
    }
}
