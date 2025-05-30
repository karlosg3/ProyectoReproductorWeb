namespace Api.Entidades
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EsPublica { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public String Slug { get; set; }
        public Boolean Habilitado { get; set; }

        public ICollection<CancionPlaylist> CancionPlaylists { get; set; }
    }
}

//Created by: Karlos