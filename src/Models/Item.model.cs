using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Item
{
  [Key]
  public int ID { get; set; }
  public int ID_tipo { get; set; }

  [ForeignKey("ID_tipo")]
  public Tipo? Tipo { get; set; }

  public string Nome { get; set; }
  public string Descricao { get; set; }
  public decimal Valor { get; set; }
}