namespace Api.Comun.Modelos.Like
{
    public class AgregarLikeDto
    {
        public int UsuarioId { get; set; }
        public string Tipo { get; set; } // Ejemplo: "cancion", "album", "playlist"
        public int IdReferencia { get; set; } // Id de la canción, álbum o playlist
    }
}
