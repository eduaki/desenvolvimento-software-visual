using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using API.Controllers.dto;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ItensController : ControllerBase
  {
    private readonly AppDbContext _context;

    public ItensController(AppDbContext context)
      {
        _context = context;
      }

    // GET: api/itens
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<Item>>> GetItens()
      {
        var itens = await _context.Itens
          .Include(i => i.Tipo)
          .ToListAsync();

        return Ok(itens);
      }

    // GET: api/itens/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Item>> GetItem(int id)
      {
        var item = await _context.Itens
          .Include(i => i.Tipo)
          .FirstOrDefaultAsync(i => i.ID == id);

        if (item == null)
          return NotFound(new { message = "Item não encontrado." });

        return Ok(item);
      }

    // POST: api/itens
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Item>> CriarItem([FromBody] ItemRequest request) 
    {
      var tipoExiste = await _context.Tipos.AnyAsync(t => t.ID == request.ID_tipo);
      if (!tipoExiste)
        return BadRequest(new { message = "Tipo informado não existe." });

      var newItem = new Item
      {
        ID_tipo = request.ID_tipo,
        Nome = request.Nome,
        Descricao = request.Descricao,
        Valor = request.Valor
      };

      _context.Itens.Add(newItem);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetItem), new
      {
        Id = newItem.ID,
      },newItem);

    }

    // PUT: api/itens/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AtualizarItem(int id, ItemRequest item)
    {
      var itemExistente = await _context.Itens.FindAsync(id);
      if (itemExistente == null)
        return NotFound(new { message = "Item não encontrado." });

      var tipoExiste = await _context.Tipos.AnyAsync(t => t.ID == item.ID_tipo);
      if (!tipoExiste)
        return BadRequest(new { message = "Tipo informado não existe." });

      // Atualiza campos
      itemExistente.Nome = item.Nome;
      itemExistente.Descricao = item.Descricao;
      itemExistente.Valor = item.Valor;
      itemExistente.ID_tipo = item.ID_tipo;

      await _context.SaveChangesAsync();

      return NoContent();
    }

    // DELETE: api/itens/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeletarItem(int id)
    {
      var item = await _context.Itens.FindAsync(id);
      if (item == null)
        return NotFound(new { message = "Item não encontrado." });

      var itemUso = await _context.Requisicoes.AnyAsync(req => req.Item == item);

      if (itemUso) return BadRequest(new { 
        message = "O item selecionado está em uso em uma requisição" 
      });

      _context.Itens.Remove(item);
      await _context.SaveChangesAsync();

      return Ok(new {message = "Item deletado com sucesso!"});
    }
  }
}
