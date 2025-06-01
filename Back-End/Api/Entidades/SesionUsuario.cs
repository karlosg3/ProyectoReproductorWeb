using System.ComponentModel.DataAnnotations;

namespace Api.Entidades
{
    public class SesionUsuario
    {
        [Key]
        public int Id { get; set; }   
        public bool Valido { get; set; }
        public DateTime UltimoUso { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool EsPersistente { get; set; }

    }
}
