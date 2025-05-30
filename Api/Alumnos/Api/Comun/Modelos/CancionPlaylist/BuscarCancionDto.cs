namespace Api.Comun.Modelos.CancionPlaylist
{
    public class BuscarCancionPlaylistDto
    {
        public int CancionId { get; set; }
        public int PlaylistId { get; set; }
        public int Orden { get; set; }
        // Puedes agregar más propiedades como nombre de la canción, etc.
        public string? NombreCancion { get; set; }
        public string? Artista { get; set; }
    }
}
