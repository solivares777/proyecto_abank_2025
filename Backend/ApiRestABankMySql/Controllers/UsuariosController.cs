using ApiRestABankMySql.Model;
using ApiRestABankMySql.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestABankMySql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _repo;

        public UsuariosController(UsuarioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repo.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repo.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario user)
        {
            var id = await _repo.Create(user);
            user.Id = id;
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Usuario user)
        {
            var updated = await _repo.Update(user, id);
            if (updated == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.Delete(id);
            if (deleted == 0) return NotFound();
            return NoContent();
        }
    }
}
