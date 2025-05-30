namespace Api.Comun.Modelos.CancionPlaylist
{
    public class ModificarOrdenCancionDto
    {
        public int CancionId { get; set; }
        public int PlaylistId { get; set; }
        public int NuevoOrden { get; set; }
    }
}
