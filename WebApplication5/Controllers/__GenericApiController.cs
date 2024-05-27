using Microsoft.AspNetCore.Mvc;
using WebApplication5.Interfaces;

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

        [HttpGet]
        public virtual ActionResult<IEnumerable<TEntity>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = repository.GetAll();

            return Ok(entities);
        }

        [HttpGet("{id}")]
        public ActionResult<TEntity> GetOne(int id)
        {
            var foundEntity = repository.GetById(id);

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }


        [HttpPost]
        public ActionResult<TEntity> Create([FromBody] TEntity toCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = repository.Add(toCreate);

            return Ok(created);
        }

        [HttpPatch("{id}")]
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


        [HttpDelete("{id}")]
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
