using Microsoft.AspNetCore.Mvc;
using Project001.Domain.Entities;
using Project001.Domain.Interfaces;

namespace Project001.Services.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ============================
        // POST - Criar contato
        // ============================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Contato contato)
        {
            if (contato == null)
                return BadRequest("Contato inválido.");

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                await _unitOfWork.ContatoRepository.CreateAsync(contato);

                await _unitOfWork.CommitAsync();

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = contato.Id },
                    contato
                );
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return StatusCode(500, ex.Message);
            }
        }

        // ============================
        // GET - Buscar por Id
        // ============================
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var contato = await _unitOfWork
                .ContatoRepository
                .GetByIdAsync(id);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }

        // ============================
        // GET - Listar todos (paginado)
        // ============================
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int limit = 10)
        {
            var contatos = await _unitOfWork
                .ContatoRepository
                .GetAllAsync(page, limit);

            return Ok(contatos);
        }

        // ============================
        // PUT - Atualizar
        // ============================
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Contato contato)
        {
            if (id != contato.Id)
                return BadRequest("Id não confere.");

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                await _unitOfWork.ContatoRepository.UpdateAsync(contato);

                await _unitOfWork.CommitAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return StatusCode(500, ex.Message);
            }
        }

        // ============================
        // DELETE - Remover
        // ============================
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var contato = await _unitOfWork
                    .ContatoRepository
                    .GetByIdAsync(id);

                if (contato == null)
                    return NotFound();

                await _unitOfWork.BeginTransactionAsync();

                await _unitOfWork.ContatoRepository.DeleteAsync(contato);

                await _unitOfWork.CommitAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return StatusCode(500, ex.Message);
            }
        }
    }
}
