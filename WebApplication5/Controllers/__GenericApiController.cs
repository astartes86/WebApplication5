using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication5.Commands.CRUD.Create;
using WebApplication5.Commands.CRUD.Delete;
using WebApplication5.Commands.CRUD.Update;
using WebApplication5.Interfaces;
using WebApplication5.Queries.GetAllEntities;


namespace WebApplication5.Controllers
{
    public abstract class GenericApiController<TEntity> : ControllerBase
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> repository;
        protected readonly IMediator _mediator;
        protected IAddRepository bind;

        protected GenericApiController(IRepository<TEntity> repository, IAddRepository bind, IMediator mediator)
        {
            this.repository = repository;
            this.bind = bind;
            _mediator = mediator;
        }
        /*       [HttpPost("get-all")]
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
       */
        [HttpPost("get-all")]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            //    if (!ModelState.IsValid)
            //    {
            //        return BadRequest(ModelState);
            //    }
            //    var entities = await repository.GetAll();
            //    return Ok(entities);
            var query = new GetAllEntitiesQuery<TEntity>();
            var entities = await _mediator.Send(query);
            return Ok(entities);
/*            var entities = await _mediator.Send(new GetAllNotesQuery());
            return Ok(entities);*/
        }


        /// <summary>
        /// Создает экземпляр <see cref="ValidationException" /> с сообщениями об ошибках валидации
        /// </summary>
        /// <returns><see cref="" /></returns>
        protected void ThrowValidationError()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).ToList();

            //throw new ValidationException($"Обнаружена одна или более ошибок валидации.\r\n{string.Join(@"\r\n\", errors)}");
        }


        [HttpPost("get{id}")]
        public ActionResult<TEntity> GetOne(int id)
        {
            var foundEntity = repository.GetById(id);

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }


        [HttpPost("create")]
        public async Task<ActionResult<TEntity>> Create(CreateCommand<TEntity> cmd)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //var created = repository.Add(toCreate);
            //return Ok(created);
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
