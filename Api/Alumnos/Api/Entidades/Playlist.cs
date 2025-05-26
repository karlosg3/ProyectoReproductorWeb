namespace Api.Entidades
{
    public class Playlist
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<Cancion> Canciones { get; set; } = new List<Cancion>();

        public string Descripcion { get; set; }

        public bool Habilitado { get; set; }

        public string Slug { get; set; }
    }
}

//Created by: Karlos