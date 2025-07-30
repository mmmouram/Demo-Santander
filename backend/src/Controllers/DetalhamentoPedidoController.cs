using Microsoft.AspNetCore.Mvc;
using MyApp.Backend.Models;
using MyApp.Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalhamentoPedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public DetalhamentoPedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("{codigoPedido}")]
        public async Task<IActionResult> ObterDetalhamentoPedido(string codigoPedido, [FromQuery] bool carregarAutomaticamente = true)
        {
            try
            {
                var pedido = await _pedidoService.ObterDetalhamentoPedidoAsync(codigoPedido, carregarAutomaticamente);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpGet("{pedidoId}/itens")]
        public async Task<IActionResult> AtualizarItens(int pedidoId)
        {
            var itens = await _pedidoService.AtualizarItensAsync(pedidoId);
            return Ok(itens);
        }

        [HttpGet("{pedidoId}/observacoes")]
        public async Task<IActionResult> AtualizarObservacoes(int pedidoId)
        {
            var observacoes = await _pedidoService.AtualizarObservacoesAsync(pedidoId);
            return Ok(observacoes);
        }

        [HttpGet("{pedidoId}/bloqueios")]
        public async Task<IActionResult> AtualizarBloqueios(int pedidoId)
        {
            var bloqueios = await _pedidoService.AtualizarBloqueiosAsync(pedidoId);
            return Ok(bloqueios);
        }

        [HttpGet("{pedidoId}/notasFiscais")]
        public async Task<IActionResult> AtualizarNotasFiscais(int pedidoId)
        {
            var notasFiscais = await _pedidoService.AtualizarNotasFiscaisAsync(pedidoId);
            return Ok(notasFiscais);
        }

        [HttpGet("notaFiscal/{notaFiscalId}")]
        public async Task<IActionResult> DetalharNotaFiscal(int notaFiscalId)
        {
            // Endpoint para detalhar Nota Fiscal
            // Para simplificação, esse endpoint apenas retornará uma mensagem.
            // A implementação pode ser estendida para buscar e retornar os detalhes de uma nota fiscal.
            return NotFound(new { mensagem = "Detalhamento de nota fiscal ainda não implementado completamente" });
        }

        [HttpGet("{pedidoId}/{tipo}/exportar")]
        public async Task<IActionResult> ExportarParaExcel(int pedidoId, string tipo)
        {
            // Valida o tipo da lista: "itens", "observacoes", "bloqueios", "notasFiscais"
            IEnumerable<object> lista = tipo.ToLower() switch
            {
                "itens" => await _pedidoService.AtualizarItensAsync(pedidoId),
                "observacoes" => await _pedidoService.AtualizarObservacoesAsync(pedidoId),
                "bloqueios" => await _pedidoService.AtualizarBloqueiosAsync(pedidoId),
                "notasfiscais" => await _pedidoService.AtualizarNotasFiscaisAsync(pedidoId),
                _ => null
            };

            if (lista == null || !lista.Any())
            {
                return BadRequest(new { mensagem = "Não há dados para exportar" });
            }

            // Simula a geração do arquivo Excel
            byte[] conteudoExcel = System.Text.Encoding.UTF8.GetBytes("Simulação do conteúdo do Excel");
            return File(conteudoExcel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{tipo}_{pedidoId}.xlsx");
        }

        [HttpPost("salvar-configuracoes")]
        public IActionResult SalvarConfiguracoes([FromBody] ConfiguracaoUsuario configuracaoUsuario)
        {
            // Aqui, as configurações do usuário seriam salvas em um arquivo ou banco de dados.
            // A implementação é simulada e retorna apenas uma mensagem de sucesso.
            return Ok(new { mensagem = "Configurações salvas com sucesso" });
        }
    }
}
