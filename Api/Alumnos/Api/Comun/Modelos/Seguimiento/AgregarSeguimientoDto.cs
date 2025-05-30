namespace Api.Comun.Modelos.Seguimiento
{
    public class CrearSeguimientoDto
    {
        public int UsuarioId { get; set; }         // Usuario que sigue
        public string ObjetivoTipo { get; set; }   // "artista", "playlist", "usuario"
        public int IdObjetivo { get; set; }        // ID del artista/playlist/usuario seguido
    }
}
