namespace Api.Comun.Modelos.Tarjetas;

public class CrearTarjetaDto
{
    public string Slug { get; set; }
    public string Nombre { get; set; }
    public string TipoCredito { get; set; }
    public decimal TasaInteres { get; set; }
    public decimal CantidadCredito { get; set; }
    public string Descripcion { get; set; }
    public int? Orden { get; set; }
    
    public int IdLista { get; set; }
    
    public List<string> UsuarioNombres  { get; set; }
    public bool Habilitado { get; set; }
}