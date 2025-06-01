using Api.Comun.Interfaces;

namespace Api.Entidades;

public class Board : ISlug
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Slug { get; set; }
    public bool Habilitado { get; set; }
    
    public virtual ICollection<Lista> Listas  { get; set; } = new List<Lista>();
 
    public string ObtenerDescripcionParaSlug()
    {
        return $"{Nombre}";
    }
}