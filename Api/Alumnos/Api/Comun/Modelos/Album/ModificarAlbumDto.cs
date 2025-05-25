using System.ComponentModel.DataAnnotations;

namespace Api.Comun.Modelos.Album
{
    public class ModificarAlbumDto
    {
        [Required]
        public string Slug { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
    }
}
