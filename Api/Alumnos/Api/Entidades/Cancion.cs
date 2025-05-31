using System.ComponentModel.DataAnnotations;
using Api.Comun.Interfaces;

namespace Api.Entidades
{
    public class Cancion
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public TimeSpan Duracion { get; set; }
        [Required]
        public string ArchivoAudio { get; set; }
        [Required]
        public int NumeroPista { get; set; }
        [Required]
        public DateTime FechaLanzamiento { get; set; } = DateTime.Now;
        public string Slug { get; set; }
        [Required]
        public bool Habilitado { get; set; } = true;
        public string Portada { get; set; }
        //Relaciones a Uno
        [Required]
        public int IdAlbum { get; set; }
        public Album Album { get; set; }
        [Required]
        public int IdArtista { get; set; }
        public Artista Artista { get; set; }

        //Relaciones Muchos
        public ICollection<CancionPlaylist> CancionPlaylists { get; set; }
    }
}