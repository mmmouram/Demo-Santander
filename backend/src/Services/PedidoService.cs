using MyApp.Backend.Models;
using MyApp.Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Backend.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pedido> ObterDetalhamentoPedidoAsync(string codigoPedido, bool carregarAutomaticamente)
        {
            var pedido = await _pedidoRepository.ObterPedidoPorCodigoAsync(codigoPedido);
            if (pedido == null)
            {
                throw new Exception("Pedido não encontrado");
            }

            if (carregarAutomaticamente)
            {
                pedido.Itens = (await _pedidoRepository.ObterItensDoPedidoAsync(pedido.Id)).ToList();
                pedido.Observacoes = (await _pedidoRepository.ObterObservacoesAsync(pedido.Id)).ToList();
                pedido.Bloqueios = (await _pedidoRepository.ObterBloqueiosAsync(pedido.Id)).ToList();
                pedido.NotasFiscais = (await _pedidoRepository.ObterNotasFiscaisAsync(pedido.Id)).ToList();
            }
            return pedido;
        }

        public async Task<IEnumerable<ItemPedido>> AtualizarItensAsync(int pedidoId)
        {
            return await _pedidoRepository.ObterItensDoPedidoAsync(pedidoId);
        }

        public async Task<IEnumerable<Observacao>> AtualizarObservacoesAsync(int pedidoId)
        {
            return await _pedidoRepository.ObterObservacoesAsync(pedidoId);
        }

        public async Task<IEnumerable<Bloqueio>> AtualizarBloqueiosAsync(int pedidoId)
        {
            return await _pedidoRepository.ObterBloqueiosAsync(pedidoId);
        }

        public async Task<IEnumerable<NotaFiscal>> AtualizarNotasFiscaisAsync(int pedidoId)
        {
            return await _pedidoRepository.ObterNotasFiscaisAsync(pedidoId);
        }
    }
}
