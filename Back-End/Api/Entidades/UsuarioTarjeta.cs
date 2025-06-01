namespace Api.Entidades;

public class UsuarioTarjeta
{ 
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public int TarjetaId { get; set; }
    public Tarjeta Tarjeta { get; set; }
}