using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication5.Extensions;
using WebApplication5.Interfaces;
using WebApplication5.Ordering;
using WebApplication5.Pagination;

namespace WebApplication5.Controllers
{
    public abstract class GenericApiController<TEntity> : ControllerBase
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> repository;

        protected GenericApiController(IRepository<TEntity> repository)
        {
            this.repository = repository;
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
        public virtual ActionResult<IEnumerable<TEntity>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = repository.GetAll();

            return Ok(entities);
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
        public ActionResult<TEntity> Create([FromBody] TEntity toCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = repository.Add(toCreate);

            return Ok(created);
        }

        [HttpPost("update{id}")]
        public ActionResult<TEntity> Update(int id, [FromBody] TEntity toUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = repository.Update(id, toUpdate);

            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }


        [HttpPost("delete{id}")]
        public ActionResult<TEntity> Delete(int id)
        {
            var entity = repository.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            repository.Delete(entity);

            return Ok(entity);
        }
    }
}
