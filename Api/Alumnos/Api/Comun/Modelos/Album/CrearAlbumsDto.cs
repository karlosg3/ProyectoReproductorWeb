using System.ComponentModel.DataAnnotations;
using Api.Entidades;

namespace Api.Comun.Modelos.Album
{
    public class CrearAlbumsDto
    {
        public string Slug { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaSalida { get; set; } = DateTime.Now;
        [Required]
        public TimeSpan Duracion { get; set; }
        [Required]
        public int CantidadCanciones { get; set; }
        public string Portada { get; set; }
        [Required]
        public int IdArtista { get; set; }
        [Required]
        public int IdGenero { get; set; }
        public bool Habilitado { get; set; } = true;
    }
}
