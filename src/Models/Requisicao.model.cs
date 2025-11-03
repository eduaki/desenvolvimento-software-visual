using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
public class Requisicao
{
    [Key]
    public int ID { get; set; }

    public int ID_item { get; set; }

    public int ID_usuario { get; set; }

    [ForeignKey("ID_item")]
    public Item Item { get; set; } = null!;

    [ForeignKey("ID_usuario")]
    public Usuario Usuario { get; set; } = null!;

    public string Status { get; set; }= null!;
    public DateTime DataRequisicao { get; set; }

}
