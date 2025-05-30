using System.ComponentModel.DataAnnotations;

namespace Api.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Slug { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
