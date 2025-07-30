using System;

namespace MyApp.Backend.Models
{
    public class NotaFiscal
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public DateTime DataEmissao { get; set; }
        public DateTime DataSaida { get; set; }
        public decimal ValorIPI { get; set; }
        public decimal ValorICMS { get; set; }
        public string Status { get; set; }
        public string Serie { get; set; }
    }
}
