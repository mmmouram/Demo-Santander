using System.Collections.Generic;

namespace MyApp.Backend.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string CodigoPedido { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }

        public ICollection<ItemPedido> Itens { get; set; }
        public ICollection<Observacao> Observacoes { get; set; }
        public ICollection<Bloqueio> Bloqueios { get; set; }
        public ICollection<NotaFiscal> NotasFiscais { get; set; }
    }
}
