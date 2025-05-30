namespace Api.Entidades
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Imagen { get; set; }
        public string? Descripcion { get; set; }
        public string Slug { get; set; }
        public bool Habilitado { get; set; }

        public ICollection<Album> Albums { get; set; } = new List<Album>();
        public ICollection<Cancion> Canciones { get; set; } = new List<Cancion>();
        public ICollection<Colaboracion> Colaboraciones { get; set; } = new List<Colaboracion>();
        public ICollection<AlbumArtista> AlbumArtistas { get; set; }
    }
}
