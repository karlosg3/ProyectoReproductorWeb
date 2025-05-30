namespace Api.Entidades
{
    public class Seguimiento
    {
        public Seguimiento(string objetivoTipo, int objetivoId)
        {
            if (!new[] { "artista", "playlist", "usuario", "album" }.Contains(objetivoTipo.ToLower()))
            {
                throw new ArgumentException("Tipo de objetivo no válido. Debe ser 'artista', 'playlist', 'album' o 'usuario'.");
            }
            ObjetivoTipo = objetivoTipo.ToLower();
            ObjetivoId = objetivoId;
        }
        public string ObjetivoTipo { get; set; } // "artista", "playlist", "usuario", "album"
        public int ObjetivoId { get; set; }
        public DateTime FechaSeguimiento { get; set; } = DateTime.UtcNow;
        public bool Activo { get; set; } = true;

        public int UsuarioId { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
