using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RequisicoesController : ControllerBase
  {
    private readonly AppDbContext _context;

    public RequisicoesController(AppDbContext context)
      {
        _context = context;
      }

    // GET: api/requisicoes
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<Requisicao>>> GetRequisicoes()
      {
        var requisicoes = await _context.Requisicoes
          // .Include(i => i.tipo)
          .ToListAsync();

        return Ok(requisicoes);
      }

    // GET: api/requisicoes/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Requisicao), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Requisicao>> GetRequisicao(int id)
      {
        var requisicao = await _context.Requisicoes
          // .Include(i => i.Tipo)
          .FirstOrDefaultAsync(i => i.ID == id);

        if (requisicao == null)
          return NotFound(new { message = "Requisição não encontrada não encontrado." });

        return Ok(requisicao);
      }

    // POST: api/requisicoes
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Requisicao>> CriarRequisicao(Requisicao requisicao)
    {
      // valida se o tipo existe
      // var tipoExiste = await _context.Tipos.AnyAsync(t => t.ID == item.ID_tipo);
      // if (!tipoExiste)
      //     return BadRequest(new { message = "Tipo informado não existe." });

      _context.Requisicoes.Add(requisicao);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetRequisicao), new { id = requisicao.ID }, requisicao);
    }

    // DELETE: api/requisicoes/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeletarRequisicao(int id)
    {
      var requisicao = await _context.Requisicoes.FindAsync(id);
      if (requisicao == null)
        return NotFound(new { message = "Requisicao não encontrado." });

      _context.Requisicoes.Remove(requisicao);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
