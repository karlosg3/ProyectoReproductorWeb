namespace Api.Comun.Modelos.Like
{
    public class HabilitarLikeDto
    {
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }      // "cancion", "album", "playlist"
        public int IdReferencia { get; set; } // Id del objeto likeado
        public bool Habilitado { get; set; }  // true = habilitado, false = deshabilitado
    }
}
