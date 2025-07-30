namespace MyApp.Backend.Models
{
    public class ConfiguracaoUsuario
    {
        public int UsuarioId { get; set; }
        public bool CarregarAutomaticamente { get; set; }
        public string Layout { get; set; } // Pode ser um JSON representando as configurações de layout
    }
}
