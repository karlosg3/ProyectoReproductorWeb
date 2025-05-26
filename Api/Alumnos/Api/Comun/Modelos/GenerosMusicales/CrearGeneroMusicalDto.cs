using System.ComponentModel.DataAnnotations;

namespace Api.Comun.Modelos.GenerosMusicales
{
    public class CrearGeneroMusicalDto
    {
        [Required]
        public string Nombre { get; set; } = string.Empty; /*Para que no sea null*/
    }
}
