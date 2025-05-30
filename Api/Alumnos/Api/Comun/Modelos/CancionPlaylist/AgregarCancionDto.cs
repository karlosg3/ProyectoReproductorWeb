namespace Api.Comun.Modelos.CancionPlaylist
{
    public class AgregarCancionAPlaylistDto
    {
        public int CancionId { get; set; }
        public int PlaylistId { get; set; }
        public int Orden { get; set; }
    }
}
