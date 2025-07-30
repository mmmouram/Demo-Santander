using Microsoft.EntityFrameworkCore;
using MyApp.Backend.Models;

namespace MyApp.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Observacao> Observacoes { get; set; }
        public DbSet<Bloqueio> Bloqueios { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
    }
}
