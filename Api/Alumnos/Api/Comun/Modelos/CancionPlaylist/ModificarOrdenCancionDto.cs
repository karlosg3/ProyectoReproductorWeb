namespace Api.Comun.Modelos.CancionPlaylist
{
    public class ModificarOrdenCancionDto
    {
        public int IdCancion { get; set; }
        public int IdPlaylist { get; set; }
        public int NuevoOrden { get; set; }
    }
}
