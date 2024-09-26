using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Commands.CRUD.Create;
using WebApplication5.Commands.CRUD.Delete;
using WebApplication5.Commands.CRUD.Update;
using WebApplication5.Interfaces;
using WebApplication5.Queries.GetAllEntities;
using WebApplication5.Queries.GetEntity;

namespace WebApplication5.Controllers
{
    public abstract class GenericApiController<TEntity> : ControllerBase
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> repository;//удалить, но пока для памяти оставлю
        protected readonly IMediator _mediator;
        protected IAddRepository bind;

        protected GenericApiController(IRepository<TEntity> repository, IAddRepository bind, IMediator mediator)
        {
            this.repository = repository;
            this.bind = bind;
            _mediator = mediator;
        }
/*       оставляю в учебных целях не забывать:
               [HttpPost("get-all")]
               public virtual ActionResult<IEnumerable<TEntity>> GetAll([FromQuery] Pageable pageable, [FromQuery] Orderable orderable)
               {
                   if (!ModelState.IsValid)
                   {
                       ThrowValidationError();
                   }
                   var dataPage = repository.GetAll()
                                               .ApplyOrder(orderable)
                                               .Paginate(pageable)
                                               ;
                   return Ok(dataPage);
               }

                protected void ThrowValidationError()
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).ToList();

                    //throw new ValidationException($"Обнаружена одна или более ошибок валидации.\r\n{string.Join(@"\r\n\", errors)}");
                }*/


        [HttpPost("get-all")]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            var entities = await _mediator.Send(new GetAllEntitiesQuery<TEntity>());
            return Ok(entities);
        }


        [HttpPost("get")]//[HttpPost("get{id}")]
        public async Task<ActionResult<TEntity>> GetOne(GetQuery<TEntity> query)
        {
            //var foundEntity = repository.GetById(id);
            var queryEntity = await _mediator.Send(query);
            if (queryEntity == null)
            {
                return NotFound();
                //return BadRequest("This note does not exist")
            } 

            return Ok(queryEntity);
        }


        [HttpPost("create")]
        public async Task<ActionResult<TEntity>> Create(CreateCommand<TEntity> cmd)
        {
            var note = await _mediator.Send(cmd);
            return Ok(note);
        }


        [HttpPost("update")]
        //public async Task<ActionResult<TEntity>> Update([FromBody] TEntity toUpdate)
        public async Task<ActionResult<TEntity>> Update(UpdateCommand<TEntity> cmd)
        {
            var note = await _mediator.Send(cmd);
            if (note == null)
                return BadRequest("This note does not exist");
            return Ok(note);
        }


        [HttpPost("delete")]
        //public async Task<ActionResult<TEntity>> Delete(int id)
        public async Task<ActionResult> Delete(DeleteCommand<TEntity> cmd)
        {
            var noteId = await _mediator.Send(cmd);
            if (noteId == null)
                return BadRequest("This note does not exist.");
            return Ok($"Deleted note with id {noteId.Id}.");
        }
    }
}
