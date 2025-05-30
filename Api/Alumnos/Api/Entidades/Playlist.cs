using System.ComponentModel.DataAnnotations;

namespace Api.Entidades
{
    public class Playlist
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string Slug { get; set; }

        //Relaciones a Uno
        [Required]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        
        //Relaciones a Muchos
        public ICollection<CancionPlaylist> CancionPlaylists { get; set; }
    }
}

//Created by: Karlos