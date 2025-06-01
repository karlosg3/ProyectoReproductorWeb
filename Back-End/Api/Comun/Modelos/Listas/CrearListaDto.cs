namespace Api.Comun.Modelos.Listas;

public class CrearListaDto
{
    public string Slug { get; set; }
    public string Nombre { get; set; }
    public int? Orden { get; set; }
    public int IdBoard { get; set; }
    public bool Habilitado { get; set; }
}