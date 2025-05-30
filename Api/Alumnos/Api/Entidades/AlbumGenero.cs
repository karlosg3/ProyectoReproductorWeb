namespace Api.Entidades
{
    public class AlbumGenero
    {
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
