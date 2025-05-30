using System.ComponentModel.DataAnnotations;

namespace Api.Entidades
{
    public class Artista
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string? Imagen { get; set; }
        public string? Descripcion { get; set; }
        public string Slug { get; set; }
        [Required]
        public bool Habilitado { get; set; } = true;


        //Relaciones
        public ICollection<Album> Albums { get; set; } = new List<Album>();
        public ICollection<Cancion> Canciones { get; set; } = new List<Cancion>();
    }
}
