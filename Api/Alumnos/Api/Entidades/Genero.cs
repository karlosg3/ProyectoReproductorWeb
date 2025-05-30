using Api.Comun.Modelos.AlbumGenero;

namespace Api.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Album> Albums { get; set; }
        public ICollection<AlbumGenero> AlbumsGeneros { get; set; }
    }
}
