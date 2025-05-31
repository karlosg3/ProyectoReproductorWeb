using System.ComponentModel.DataAnnotations;

namespace Api.Comun.Modelos.Album
{
    public class ModificarAlbumDto
    {
        [Required]
        public string Slug { get; set; }
        public string Portada { get; set; }
        public bool Habilitado { get; set; }
    }
}
