namespace MyApp.Backend.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public string Situacao { get; set; }
    }
}
