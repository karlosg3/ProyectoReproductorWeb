namespace Api.Comun.Modelos.Tarjetas;

public class BuscarTarjetasDto
{
    public string Slug { get; set; }
    public string Nombre { get; set; }
    public string TipoCredito { get; set; }
    public decimal TasaInteres { get; set; }
    public decimal CantidadCredito { get; set; }
    public string Descripcion { get; set; }
    public bool Habilitado { get; set; }
}