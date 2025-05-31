using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Api.Entidades
{
    public class CancionPlaylist
    {
        public int Id { get; set; }
        [Required]
        public bool Habilitado { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        //Relaciones a Uno
        [Required]
        public int IdPlaylist { get; set; }
        public Playlist Playlist { get; set; }
        [Required]
        public int IdCancion { get; set; }
        public Cancion Cancion { get; set; }
    }
}