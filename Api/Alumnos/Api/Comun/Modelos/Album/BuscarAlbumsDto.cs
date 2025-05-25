namespace Api.Comun.Modelos.Album
{
    public class BuscarAlbumsDto
    {
        public string Slug { get; set; }
        public string Nombre { get; set; }
        public string Artista { get; set; }
        public ICollection<AlbumArtista> AlbumArtistas { get; set; }
        public bool Habilitado { get; set; }
    }
}
