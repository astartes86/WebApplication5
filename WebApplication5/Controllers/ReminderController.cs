using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.DAL;
using WebApplication5.Interfaces;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("/api/1.0/function/[controller]")]
    public class ReminderController : GenericApiController<Reminder>
    {
        public ReminderController(IRepository<Reminder> repository, IAddRepository bind, IMediator mediator) : base(repository, bind, mediator)
        {
        }


        [HttpPost("bind")]
        public async Task<ActionResult> Bind(int id, IEnumerable<int> tagsIds)//плюс добавим еще один контроллер, не типовой
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var binding = await bind.BindReminder(id, tagsIds);
            if (binding == null)
                return BadRequest("Wrong data for binding.");
            return Ok(binding);
        }
    }

}