using Microsoft.AspNetCore.Mvc;
using WebApplication5.DAL;
using WebApplication5.Interfaces;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("/api/1.0/function/[controller]")]
    public class TagController : GenericApiController<Tag>
    {
        public TagController(IRepository<Tag> repository) : base(repository)
        {
        }
    }
}