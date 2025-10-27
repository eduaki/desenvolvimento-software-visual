using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
public class Requisicao
{
    [Key]
    public int ID { get; set; }
    public Item Item { get; set; } = null!;

// Aguardando tabela de usuário ser criada para relacionamneto

    public string Status { get; set; }= null!;
    public DateTime DataRequisicao { get; set; }

}
