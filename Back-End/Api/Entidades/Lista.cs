using System.ComponentModel.DataAnnotations;
using Api.Comun.Interfaces;

namespace Api.Entidades;

public class Lista : ISlug
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Orden { get; set; }
    public string Slug { get; set; }
    public bool Habilitado { get; set; }
    
    public virtual ICollection<Tarjeta> Tarjetas  { get; set; } = new List<Tarjeta>();
    
    public int IdBoard { get; set; }
    public Board Board { get; set; }
    
    public string ObtenerDescripcionParaSlug()
    {
        return $"{Nombre}";
    }
}