namespace Api.Entidades
{
    public class Likes
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int CancionId { get; set; }
        public Cancion Cancion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public bool Habilitado { get; set; } = true;

        public string Slug { get; set; }
    }
}