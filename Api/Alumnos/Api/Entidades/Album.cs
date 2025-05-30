using System.ComponentModel.DataAnnotations;

namespace Api.Entidades
{
    public class Album
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaSalida { get; set; } = DateTime.Now;
        [Required]
        public TimeSpan Duracion { get; set; } 
        [Required]
        public int CantidadCanciones { get; set; }
        [Required]
        public string Portada { get; set; }
        public string Slug {  get; set; }
        [Required]
        public bool Habilitado { get; set; } = true;

        //Relaciones a Uno
        [Required]
        public int IdArtista { get; set; }
        public Artista Artista { get; set; }
        [Required]
        public int IdGenero { get; set; }
        public Genero Genero { get; set; }


        public ICollection<Cancion> Canciones { get; set; }
    }
}
