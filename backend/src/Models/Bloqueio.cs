namespace MyApp.Backend.Models
{
    public class Bloqueio
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public bool Ativo { get; set; }
        public string TipoBloqueio { get; set; } // Ex: credito, frete, margem, etc.
        public string Mensagem { get; set; }
    }
}
