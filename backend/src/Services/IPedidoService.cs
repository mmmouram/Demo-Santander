using MyApp.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Backend.Services
{
    public interface IPedidoService
    {
        Task<Pedido> ObterDetalhamentoPedidoAsync(string codigoPedido, bool carregarAutomaticamente);
        Task<IEnumerable<ItemPedido>> AtualizarItensAsync(int pedidoId);
        Task<IEnumerable<Observacao>> AtualizarObservacoesAsync(int pedidoId);
        Task<IEnumerable<Bloqueio>> AtualizarBloqueiosAsync(int pedidoId);
        Task<IEnumerable<NotaFiscal>> AtualizarNotasFiscaisAsync(int pedidoId);
    }
}
