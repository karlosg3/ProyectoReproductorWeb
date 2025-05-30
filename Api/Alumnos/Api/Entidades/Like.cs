namespace Api.Entidades
{
    public class Like
    {
        public int Id { get; set; }
        public string Tipo { get; set; } // "cancion",
        public int ReferenciaId { get; set; }
        public DateTime Fecha { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}