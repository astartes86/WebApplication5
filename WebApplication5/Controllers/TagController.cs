using Microsoft.AspNetCore.Mvc;
using WebApplication5.DAL;
using WebApplication5.Interfaces;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("/api/1.0/function/[controller]")]
    public class TagController : GenericApiController<Tag>
    {
        public TagController(IRepository<Tag> repository, IAddRepository bind) : base(repository, bind)
        {
        }


        [HttpPost("bind")]
        public async Task<ActionResult> Bind(int id, [FromQuery] IEnumerable<int> noteIds, [FromQuery] IEnumerable<int> reminderIds)//плюс добавим еще один контроллер, не типовой
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var binding = await bind.BindTag(id, noteIds, reminderIds);
            if (binding == null)
                return BadRequest("Wrong data for binding.");
            return Ok(binding);
        }
    }
}