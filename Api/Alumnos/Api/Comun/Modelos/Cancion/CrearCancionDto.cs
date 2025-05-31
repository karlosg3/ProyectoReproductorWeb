using System.ComponentModel.DataAnnotations;
using Api.Entidades;

namespace Api.Comun.Modelos.Cancion
{
    public class CrearCancionDto
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public TimeSpan Duracion { get; set; }
        [Required]
        public string ArchivoAudio { get; set; }
        [Required]
        public int NumeroPista { get; set; }
        public DateTime FechaLanzamiento { get; set; } = DateTime.Now;
        public string Portada { get; set; }
        public string? Slug { get; set; }
        [Required]
        public bool Habilitado { get; set; } = true;
        [Required]
        public int IdAlbum { get; set; }
        [Required]
        public int IdArtista { get; set; }
    }
}
