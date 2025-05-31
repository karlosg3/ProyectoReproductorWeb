namespace Api.Comun.Modelos.CancionPlaylist
{
    public class BuscarCancionPlaylistDto
    {
        public int IdCancion { get; set; }
        public int IdPlaylist { get; set; }
        public DateTime FechaRegistro { get; set; }
        // Puedes agregar más propiedades como nombre de la canción, etc.
        public string? NombreCancion { get; set; }
        public string? Artista { get; set; }
    }
}
