using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
  public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
  {
    public DbSet<Item> Itens { get; set; }
    public DbSet<Requisicao> Requisicoes { get; set; }
    public DbSet<Tipo> Tipos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
  }
}
