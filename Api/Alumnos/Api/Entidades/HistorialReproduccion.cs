namespace Api.Entidades
{
    public class HistorialReproduccion
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int CancionId { get; set; }
        public Cancion Cancion { get; set; }
    }
}
