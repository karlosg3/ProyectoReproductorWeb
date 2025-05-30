namespace Api.Entidades
{
    public class Seguimiento
    {
        public int Id { get; set; }
        public string ObjetivoTipo { get; set; } // "artista", "playlist", "usuario"
        public int ObjetivoId { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
