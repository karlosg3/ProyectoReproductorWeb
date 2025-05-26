using System.ComponentModel.DataAnnotations;

namespace Api.Comun.Modelos.GenerosMusicales
{
    public class ModificarGeneroMusicalDto
    {
        [Required]
        public required string Slug { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty; /*Para que no sea null*/
    }
}
