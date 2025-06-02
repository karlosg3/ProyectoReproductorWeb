using System.ComponentModel.DataAnnotations;
using Api.Comun.Interfaces;

namespace Api.Entidades;

public class Tarjeta : ISlug
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string TipoCredito { get; set; }
    public decimal TasaInteres { get; set; }
    public decimal CantidadCredito { get; set; }
    public string Descripcion { get; set; }
    
    public int Orden { get; set; }
    public string Slug { get; set; }
    public bool Habilitado { get; set; }
    
    public int IdLista { get; set; }     // Foreign key
    public Lista Lista { get; set; }     // Navegación
    public virtual ICollection<UsuarioTarjeta> UsuarioTarjetas  { get; set; }
    
    public string ObtenerDescripcionParaSlug()
    {
        return $"{Nombre}";
    }
}