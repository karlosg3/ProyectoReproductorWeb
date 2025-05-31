namespace Api.Comun.Modelos.CancionPlaylist
{
    public class DeshabilitarCancionDePlaylistDto
    {
        public int IdCancion { get; set; }
        public int IdPlaylist { get; set; }
        public bool Habilitado { get; set; }
    }
}
