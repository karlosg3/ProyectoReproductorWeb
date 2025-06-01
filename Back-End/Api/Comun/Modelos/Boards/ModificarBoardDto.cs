using System.ComponentModel.DataAnnotations;

namespace Api.Comun.Modelos.Boards;

public class ModificarBoardDto
{
    [Required] 
    public string Slug { get; set; }
    public string Nombre { get; set; }
    public bool Habilitado { get; set; }
}