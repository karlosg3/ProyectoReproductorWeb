namespace Api.Comun.Modelos.Playlist
{
    public class ModificarPlaylistDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
        public string Visibilidad { get; set; }
    }
}
