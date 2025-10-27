using System.ComponentModel.DataAnnotations;

namespace API.Controllers.dto;
public class ItemRequest
{
  [Required(ErrorMessage = "O ID do tipo é obrigatório")]
  public int ID_tipo { get; set; }

  [Required(ErrorMessage = "O nome é obrigatório")]
  [MaxLength(100)]
  public string Nome { get; set; }

  // Descrição é opcional, então não colocamos [Required]
  [MaxLength(500)]
  public string Descricao { get; set; }

  [Required(ErrorMessage = "O valor é obrigatório")]
  [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
  public decimal Valor { get; set; }
}