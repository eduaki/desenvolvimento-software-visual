using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<Item> Itens { get; set; }
    // public DbSet<Item> Itens { get; set; }
    // public DbSet<Tipo> Tipos { get; set; }
    // public DbSet<Requisicao> Requisicoes { get; set; }
  }
}
