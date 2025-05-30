using System.ComponentModel.DataAnnotations;

namespace Api.Entidades
{
    public class SesionUsuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool Valido { get; set; }
        [Required]
        public DateTime UltimoUso { get; set; } = DateTime.Now;
        [Required]
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public DateTime? FechaFin { get; set; }
        [Required]
        public bool EsPersistente { get; set; } = true;

        //Relacion a Uno
        [Required]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

    }
}
