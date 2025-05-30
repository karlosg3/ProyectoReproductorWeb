namespace Api.Comun.Modelos.Like
{
    public class AgregarLikeDto
    {
        public int UsuarioId { get; set; }
        public int CancionId { get; set; }
        public bool Habilitado { get; set; }
    }
}
