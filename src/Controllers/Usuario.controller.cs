using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsuariosController : ControllerBase
  {
    private readonly AppDbContext _context;

    public UsuariosController(AppDbContext context)
    {
      _context = context;
    }

    // GET: api/usuarios
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
      var usuarios = await _context.Usuarios.ToListAsync();
      return Ok(usuarios);
    }

    // GET: api/usuarios/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
      var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

      if (usuario == null)
        return NotFound(new { message = "Usuário não encontrado." });

      return Ok(usuario);
    }

    // POST: api/usuarios
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Usuario>> CriarUsuario(Usuario usuario)
    {
      _context.Usuarios.Add(usuario);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
    }

    // PUT: api/usuarios/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AtualizarUsuario(int id, Usuario usuario)
    {
      if (id != usuario.Id)
        return BadRequest(new { message = "ID do usuário não corresponde ao parâmetro." });

      var usuarioExistente = await _context.Usuarios.FindAsync(id);
      if (usuarioExistente == null)
        return NotFound(new { message = "Usuário não encontrado." });

      // Atualiza campos
      usuarioExistente.Nome = usuario.Nome;
      usuarioExistente.Cpf = usuario.Cpf;
      usuarioExistente.Area = usuario.Area;
      usuarioExistente.Endereco = usuario.Endereco;
      usuarioExistente.Telefone = usuario.Telefone;
      usuarioExistente.Email = usuario.Email;
      usuarioExistente.Data_Nascimento = usuario.Data_Nascimento;

      await _context.SaveChangesAsync();

      return NoContent();
    }

    // DELETE: api/usuarios/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeletarUsuario(int id)
    {
      var usuario = await _context.Usuarios.FindAsync(id);
      if (usuario == null)
        return NotFound(new { message = "Usuário não encontrado." });

      _context.Usuarios.Remove(usuario);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
