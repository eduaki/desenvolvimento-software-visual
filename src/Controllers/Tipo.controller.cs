using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TiposController : ControllerBase
  {
    private readonly AppDbContext _context;

public TiposController(AppDbContext context)
    {
      _context = context;
    }

    // GET: api/tipos
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<Item>>> GetTipos()
      {
        var tipos = await _context.Tipos.ToListAsync();

        return Ok(tipos);
      }

    // GET: api/tipos/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Tipo>> GetTipo(int id)
      {
        var tipos = await _context.Tipos.FirstOrDefaultAsync(i => i.ID == id);

        if (tipos == null)
          return NotFound(new { message = "Tipo não encontrado." });

        return Ok(tipos);
      }

    // POST: api/tipos
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Tipo>> CriarTipo(Tipo tipo)
    {

      if (tipo.Nome == "" || tipo.Nome == null) 
        return BadRequest(new { message = "O campo 'Nome' é Obrigatório" });

      // valida se o tipo existe
      var tipoExiste = await _context.Tipos.AnyAsync(t => t.Nome == tipo.Nome);
      var idTipoExistente = await _context.Tipos.AnyAsync(t => t.ID == tipo.ID);
      if (tipoExiste || idTipoExistente)
        return BadRequest(new { message = "Tipo informado já cadastrado." });

      _context.Tipos.Add(tipo);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetTipo), new { id = tipo.ID }, tipo);
    }

    // PUT: api/tipos/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AtualizarTipo(int id, Tipo tipo)
    {
      if (id != tipo.ID)
        return BadRequest(new { message = "ID do tipo não corresponde ao parâmetro." });

      var tipoExistente = await _context.Tipos.FindAsync(id);
      if (tipoExistente == null)
        return NotFound(new { message = "Tipo não encontrado." });

      // Atualiza campos
      tipoExistente.Nome = tipo.Nome;

      await _context.SaveChangesAsync();

      return NoContent();
    }

    // DELETE: api/tipos/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeletarTipo(int id)
    {
      var tipoEmUso = await _context.Itens.AnyAsync(item => item.ID_tipo == id); 
      if (tipoEmUso)
      {
        return BadRequest(new { message = "Este tipo está sendo usado por um item e não pode ser excluído." });
      }

      var tipo = await _context.Tipos.FindAsync(id);
      if (tipo == null)
      {
        return NotFound(new { message = "Tipo não encontrado." });
      }
      
      _context.Tipos.Remove(tipo);
        await _context.SaveChangesAsync();

      return Ok(new {message = "Tipo deletado com sucesso"}); 
    }
  }
}
