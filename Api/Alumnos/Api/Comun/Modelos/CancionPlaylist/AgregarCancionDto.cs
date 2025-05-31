namespace Api.Comun.Modelos.CancionPlaylist
{
    public class AgregarCancionAPlaylistDto
    {
        public int IdCancion { get; set; }
        public int IdPlaylist { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
