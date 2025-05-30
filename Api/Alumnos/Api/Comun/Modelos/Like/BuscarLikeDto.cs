namespace Api.Comun.Modelos.Like
{
    public class BuscarLikeDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public int IdReferencia { get; set; }
        public DateTime Fecha { get; set; }
    }
}
