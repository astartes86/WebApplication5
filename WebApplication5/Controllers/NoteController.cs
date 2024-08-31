using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.DAL;
using WebApplication5.Interfaces;
using WebApplication5.Repositories;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("/api/1.0/function/[controller]")]
    public class NoteController : GenericApiController<Note>
    {
        //private NoteTagRepository repository=new(MemoryDbContext());

        //private static MemoryDbContext MemoryDbContext()
        //{
        //    throw new NotImplementedException();
        //}

        //private IBind repository;

        public NoteController(IRepository<Note> repository,IAddRepository bind) : base(repository,bind)   //задействуем все контроллеры описанные в генерике
        {
        }



        [HttpPost("bind")]
        public async Task<ActionResult> Bind(int id, IEnumerable<int> tagsIds)//плюс добавим еще один контроллер, не типовой
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var binding = await bind.BindNote(id, tagsIds);
            if (binding == null)
                return BadRequest("Wrong data for binding.");
            return Ok(binding);
        }



    }
}