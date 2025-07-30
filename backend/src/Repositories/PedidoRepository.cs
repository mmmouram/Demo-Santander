using Microsoft.EntityFrameworkCore;
using MyApp.Backend.Data;
using MyApp.Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Backend.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _dbContext;

        public PedidoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pedido> ObterPedidoPorCodigoAsync(string codigoPedido)
        {
            return await _dbContext.Pedidos
                .Include(p => p.Itens)
                .Include(p => p.Observacoes)
                .Include(p => p.Bloqueios)
                .Include(p => p.NotasFiscais)
                .FirstOrDefaultAsync(p => p.CodigoPedido == codigoPedido);
        }

        public async Task<IEnumerable<ItemPedido>> ObterItensDoPedidoAsync(int pedidoId)
        {
            return await _dbContext.ItensPedido
                .Where(i => i.PedidoId == pedidoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Observacao>> ObterObservacoesAsync(int pedidoId)
        {
            return await _dbContext.Observacoes
                .Where(o => o.PedidoId == pedidoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bloqueio>> ObterBloqueiosAsync(int pedidoId)
        {
            return await _dbContext.Bloqueios
                .Where(b => b.PedidoId == pedidoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<NotaFiscal>> ObterNotasFiscaisAsync(int pedidoId)
        {
            return await _dbContext.NotasFiscais
                .Where(n => n.PedidoId == pedidoId)
                .ToListAsync();
        }
    }
}
