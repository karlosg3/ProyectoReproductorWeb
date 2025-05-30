namespace Api.Entidades
{
    public class Like
    {
        public DateTime Fecha { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int CancionId { get; set; }
        public Cancion Cancion { get; set; }


    }
}