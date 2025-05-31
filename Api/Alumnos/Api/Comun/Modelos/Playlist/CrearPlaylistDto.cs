namespace Api.Comun.Modelos.Playlist
{
    public class CrearPlaylistDto
    {
        public string Nombre { get; set; }       // Creador de la playlist
        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }
    }
}
