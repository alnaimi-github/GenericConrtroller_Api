using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GenericController.Api.Repositories.IRepository;
using GenericController.Api.Models;

namespace GenericController.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<T> : ControllerBase where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository;

        protected BaseController(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity =await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] T entity)
        {
          await  _repository.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] T entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            var existingEntity =await _repository.GetByIdAsync(id);
            if (existingEntity == null)
            {
                return NotFound();
            }

          await  _repository.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity =await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

           await _repository.DeleteAsync(id);
            return NoContent();
        }
    }

}
