namespace Api.Entidades
{
    public class Seguimiento
    {
        public Seguimiento(int usuarioId, string objetivoTipo, int objetivoId)
        {
            if (!new[] { "artista", "playlist", "usuario", "album" }.Contains(objetivoTipo.ToLower()))
            {
                throw new ArgumentException("Tipo de objetivo no válido. Debe ser 'artista', 'playlist', 'album' o 'usuario'.");
            }
            UsuarioId = usuarioId;
            ObjetivoTipo = objetivoTipo.ToLower();
            ObjetivoId = objetivoId;
        }
        public int Id { get; set; }
        public string ObjetivoTipo { get; set; } // "artista", "playlist", "usuario", "album"
        public int ObjetivoId { get; set; }
        public DateTime FechaSeguimiento { get; set; } = DateTime.UtcNow;
        public bool Activo { get; set; } = true;

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
