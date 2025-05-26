namespace Api.Entidades
{
    public class CancionPlaylist
    {
        public int CancionId { get; set; }
        public Cancion Cancion { get; set; }

        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public bool Habilitado { get; set; } = true;

        public string Slug { get; set; }
    }
}