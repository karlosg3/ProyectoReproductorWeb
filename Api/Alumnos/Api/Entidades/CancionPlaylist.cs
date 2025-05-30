namespace Api.Entidades
{
    public class CancionPlaylist
    {
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }

        public int CancionId { get; set; }
        public Cancion Cancion { get; set; }

        public int Orden { get; set; }

        public bool Habilitado { get; set; }
    }
}