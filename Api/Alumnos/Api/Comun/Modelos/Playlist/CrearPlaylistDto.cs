namespace Api.Comun.Modelos.Playlist
{
    public class CrearPlaylistDto
    {
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }         // Creador de la playlist
        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
        public bool EsPublica { get; set; }    // "privada" o "publica"
    }
}
