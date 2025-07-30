using MyApp.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Backend.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> ObterPedidoPorCodigoAsync(string codigoPedido);
        Task<IEnumerable<ItemPedido>> ObterItensDoPedidoAsync(int pedidoId);
        Task<IEnumerable<Observacao>> ObterObservacoesAsync(int pedidoId);
        Task<IEnumerable<Bloqueio>> ObterBloqueiosAsync(int pedidoId);
        Task<IEnumerable<NotaFiscal>> ObterNotasFiscaisAsync(int pedidoId);
    }
}
