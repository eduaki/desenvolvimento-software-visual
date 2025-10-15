using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }

    public string Nome { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string Area { get; set; } = null!;
    public string Endereco { get; set; } = null!;
    public string Telefone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Data_Nascimento { get; set; } = null!;
}
